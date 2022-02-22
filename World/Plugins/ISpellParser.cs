using System.Threading.Tasks;
using SharedUtil;
using World.Magic;

namespace World.Plugins
{
    public interface ISpellParser
    {
        Task<ResultOrError<Spell>> Parse(string spell);
    }
}
