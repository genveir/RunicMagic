using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;
using World.Magic;

namespace Engine.Commands
{
    public class Speaking
    {
        public static bool TryParse(Player player, string spellstring, out Spell? spell)
        {
            var parsed = SpellParser.Parse(player, spellstring);

            if (parsed.IsError) spell = null;
            else spell = parsed.Result;
            
            return !parsed.IsError;
        }
    }
}
