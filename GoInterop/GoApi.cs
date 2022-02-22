using System.Text;
using System.Text.Json;
using SharedUtil;
using World.Creatures;
using World.Magic;
using World.Magic.Effects;
using World.Plugins;

namespace GoInterop
{
    public class GoApi : IMagicHandler, ISpellParser
    {
        readonly HttpClient _client;

        public GoApi(long port)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri($"http://localhost:{port}"),
                Timeout = TimeSpan.FromMilliseconds(10)
            };
        }

        private static StringContent Serialize(object content)
        {
            var json = JsonSerializer.Serialize(content);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public async Task<ResultOrError<Spell>> Parse(string spell)
        {
            try
            {
                var result = await _client.PostAsync("/spell", Serialize(spell));
                return await FormatParseResult(result);
            }
            catch (Exception e)
            {
                return new($"Could not perform request: {e.Message}");
            }
        }

        public async Task<ResultOrError<Spell>> FormatParseResult(HttpResponseMessage result)
        {

            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStreamAsync();

                try
                {
                    var id = await JsonSerializer.DeserializeAsync<Guid>(body);

                    return new(Spell.From(id));
                }
                catch (JsonException e)
                {
                    return new(e.Message);
                }
            }
            else
            {
                var body = await result.Content.ReadAsStringAsync();

                return new($"Magic Api returned {result.StatusCode} with body {body}");
            }
        }

        public async Task<ResultOrError<string>> GetAsText(Spell spell)
        {
            try
            {
                var result = await _client.GetAsync($"/spell/{spell.Value}");
                return await ParseGetAsTextResult(result);
            }
            catch (Exception e)
            {
                return new($"Could not perform request: {e.Message}");
            }
        }

        public async Task<ResultOrError<string>> ParseGetAsTextResult(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStreamAsync();

                try
                {
                    var text = await JsonSerializer.DeserializeAsync<string>(body);

                    return new(text ?? "");
                }
                catch (JsonException e)
                {
                    return new(e.Message);
                }
            }
            else
            {
                var body = await result.Content.ReadAsStringAsync();

                return new($"Magic Api returned {result.StatusCode} with body {body}");
            }
        }

        public async Task<ResultOrError<IEnumerable<ISpellEffect>?>> DoStep(Spell spell)
        {
            try
            {
                var result = await _client.GetAsync($"/spell/{spell.Value}/step");
                return await FormatDoStepResult(result);
            }
            catch (Exception e)
            {
                return new($"Could not perform request: {e.Message}");
            }
        }

        public async Task<ResultOrError<IEnumerable<ISpellEffect>?>> FormatDoStepResult(HttpResponseMessage result)
        {
            if (result.IsSuccessStatusCode)
            {
                var body = await result.Content.ReadAsStreamAsync();

                try
                {
                    var effectDTOs = await JsonSerializer.DeserializeAsync<IEnumerable<SpellEffectDTO>>(body);
                    effectDTOs ??= Enumerable.Empty<SpellEffectDTO>();

                    var effects = SpellEffectMapper.MapEffects(effectDTOs);

                    return new(effects);
                }
                catch (JsonException e)
                {
                    return new(e.Message);
                }
            }
            else
            {
                var body = await result.Content.ReadAsStringAsync();

                return new($"Magic Api returned {result.StatusCode} with body {body}");
            }
        }
    }
}