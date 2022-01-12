using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;
using World.Rooms;

namespace Engine.Commands
{
    public static class CommandParser
    {
        public static bool Parse(Player player, string command)
        {
            return TryParseMovement(player, command) ||
                TryParseSingleWordCommands(player, command);
        }

        private static bool TryParseMovement(Player player, string command)
        {
            switch (command)
            {
                case "n":
                case "north": player.Move(Direction.NORTH); return true;
                case "e":
                case "east": player.Move(Direction.EAST); return true;
                case "s":
                case "south": player.Move(Direction.SOUTH); return true;
                case "w":
                case "west": player.Move(Direction.WEST); return true;
                case "u":
                case "up": player.Move(Direction.UP); return true;
                case "d":
                case "down": player.Move(Direction.DOWN); return true;
                default: return false;
            }
        }

        private static bool TryParseSingleWordCommands(Player player, string command)
        {
            switch(command)
            {
                case "l":
                case "look": player.Look(); return true;
                default: return false;
            }
        }
    }
}
