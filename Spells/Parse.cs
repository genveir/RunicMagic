using RunicMagic.Spells;
using System.Linq;
using System.Collections.Generic;

namespace RunicMagic.Spells
{
    public class ParseResult
    {
        public ISpell spell;
        public bool success;
        public string reason;


        private ParseResult(ISpell spell, bool success, string reason = null)
        {
            this.spell = spell;
            this.success = success;
            this.reason = reason;
        }

        public static ParseResult Succeed(ISpell spell) { return new ParseResult(spell, true); }
        public static ParseResult Fail(string reason) { return new ParseResult(null, false, reason); }
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
                    return ParseResult.Fail("lookup failed");
                }
                runes.Push(r);
            }
            var root = runes.Pop();
            if (!root.Parse(runes))
            {
                return ParseResult.Fail("failed to parse spell");
            }
            if (runes.Count != 0) return ParseResult.Fail("not all runes were used");
            return ParseResult.Succeed(new Spell(root));
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