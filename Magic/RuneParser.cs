using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using World.Creatures;
using OneOf;

namespace Magic
{
    public static class RuneParser
    {
        public static Spell? Parse(Player player, string spellstring)
        {
            IEnumerable<Rune> runes;
            try {
                runes = ReadRunes(player, spellstring);
            }
            catch(RuneParseException){
                player.Echo("But nothing happens!");
                return null;
            }

            Spellnode root;
            IEnumerable<Rune> remainder;
            try {
                (root, remainder) = ParseRunes(player, runes);
            }
            catch(RuneParseException)
            {
                player.Echo("But nothing happens!");
                return null;
            }
            if (remainder?.Any() == true)
            {
                player.Echo("But nothing happens!");
                return null;
            }
            return new Spell(root!);
        }

        private static IEnumerable<Rune> ReadRunes(Player player, string spellstring) {
            var runestrings = spellstring.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return runestrings.Select<string, Rune>(s =>
                s switch
                {
                    "ZU" => new Runes.ZU(player, player.Location),
                    "DEBUG" => new Runes.DEBUG(player, player.Location),
                    _ => throw new RuneParseException($"unknown rune {s}")
                }
            );
        }

        public static (Spellnode, IEnumerable<Rune>) ParseRunes(Player player, IEnumerable<Rune> runes) {
            if (!runes.Any())
            {
                player.Echo("But nothing happens!");
                throw new RuneParseException("expected runes but ran out");
            }
            return runes.First().Parse(player, runes.Skip(1));
        }
    }
}
