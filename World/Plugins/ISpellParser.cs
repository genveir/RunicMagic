using System.Collections.Generic;
using SharedUtil;
using World.Creatures;
using World.Magic;

namespace World.Plugins
{
    public interface ISpellParser
    {
        ResultOrError<Spell> Parse(Player player, string spellstring);

        ResultOrError<(RunePhrase, IEnumerable<Rune>)> ParseRunes(Player player, IEnumerable<Rune> runes);
    }
}
