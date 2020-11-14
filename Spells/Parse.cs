using RunicMagic.Spells;
using System.Linq;
using System.Collections.Generic;

namespace RunicMagic.Spells
{
    public class ParseResult
    {
        public ISpell spell;
        public bool success;

        public ParseResult(ISpell s, bool succ)
        {
            spell = s;
            success = succ;
        }
    }
    public static class Parser
    {
        public static ParseResult Parse(string input)
        {
            var runesRaw = input.Split(' ');
            if (runesRaw.Length == 0) return null;
            var runes = new Stack<IRune>();
            for (var i = 0; i < runesRaw.Length; i++ )
            {
                IRune r;
                var success = lookup(runesRaw[runesRaw.Length-i-1], out r);
                if (!success) {
                    return new ParseResult(null, false);
                }
                runes.Push(r);
            }
            var root = runes.Pop();
            if (!root.Parse(runes))
            {
                return new ParseResult(null, false);
            }
            if (runes.Count != 0) return new ParseResult(null, false);
            return new ParseResult(new Spell(root), true);
        }

        private static bool lookup(string runestr, out IRune rune)
        {
            switch (runestr)
            {
                case "ZU": 
                    rune = new Zu();
                    return true;
                case "BEH": 
                    rune = new Beh();
                    return true;
                case "BASDU": 
                    rune = new Basdu();
                    return true;
                case "TI": 
                    rune = new Ti();
                    return true;
                case "OH": 
                    rune = new Oh();
                    return true;
            }
            rune = null;
            return false;
        }
    }
}