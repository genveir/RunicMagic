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
        public static void Parse(Player player, string spellstring)
        {
            var result = RuneParser.Parse(player, spellstring);
            result.Switch(
                spell => spell.GetSpoken(player),
                _ => player.Echo("But nothing happens!")
            );
        }
    }
}
