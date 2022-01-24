using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using World.Creatures;
using OneOf;
using World.Magic.Runes;
using SharedUtil;

namespace World.Magic
{
    public static class SpellParser
    {
        public static ResultOrError<Spell> Parse(Player player, string spellstring)
        {
            RunePhrase root;
            IEnumerable<Rune> remainder;

            var readResult = ReadRunes(player, spellstring);
            if (readResult.IsError) return readResult.Error; // error string

            var parseResult = ParseRunes(player, readResult.Result);
            if (parseResult.IsError) return parseResult.Error; // error string

            (root, remainder) = parseResult.Result;

            if (remainder?.Any() == true)
            {
                return "Nonempty remainder when parsing full spell";
            }
            return new Spell(root!);
        }

        private static ResultOrError<IEnumerable<Rune>> ReadRunes(Player player, string spellstring)
        {
            var runestrings = spellstring.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var runes = new List<Rune>();

            foreach (var runeString in runestrings)
            {
                switch (runeString)
                {
                    case "ZU": runes.Add(new ZU(player, player.Location)); break;
                    case "BEH": runes.Add(new BEH(player, player.Location)); break;
                    case "DEBUG": runes.Add(new DEBUG(player, player.Location)); break;
                    default: return $"unknown rune {runeString}";
                }
            }
            return runes;
        }

        public static ResultOrError<(RunePhrase, IEnumerable<Rune>)> ParseRunes(Player player, IEnumerable<Rune> runes)
        {
            if (!runes.Any())
            {
                return "expected runes but ran out";
            }
            return runes.First().Parse(player, runes.Skip(1));
        }
    }
}
