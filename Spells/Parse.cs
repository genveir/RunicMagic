using RunicMagic.Spells;
using System.Linq;
using System.Collections.Generic;

namespace RunicMagic.Spells
{
    public static class Parser
    {
        public static ISpell Parse(string input)
        {
            var runesRaw = input.Split(' ');
            if (runesRaw.Length == 0) return null;
            var runes = new Stack<IRune>();
            for (var i = 0; i < runesRaw.Length; i++ )
            {
                runes.Push(lookup(runesRaw[runesRaw.Length-i-1]));
            }
            var root = runes.Pop();
            root.Parse(runes);
            if (runes.Count != 0) throw new System.Exception($"Parse error {runes.Count}");
            return new Spell(root);
        }

        private static IRune lookup(string runestr)
        {
            switch (runestr)
            {
                case "ZU": return new Zu();
                case "BEH": return new Beh();
                case "BASDU": return new Basdu();
                case "TI": return new Ti();
                case "OH": return new Oh();
            }
            throw new System.Exception("Yo verkeerde rune yoh");
        }
    }
}