using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;
using World.Magic;
using World.Plugins;

namespace Engine.Commands
{
    public class Speaking
    {
        public static bool TryParse(ISpellParser parser, Player player, string spellstring, out Spell? spell)
        {
            var parsed = parser.Parse(player, spellstring);

            if (parsed.IsError) spell = null;
            else spell = parsed.Result;
            
            return !parsed.IsError;
        }
    }
}
