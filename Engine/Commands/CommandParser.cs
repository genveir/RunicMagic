using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
using World.Creatures;
using World.Magic;
using World.Plugins;
using World.Rooms;

namespace Engine.Commands
{
    public class CommandParser
    {
        private readonly ISpellParser _spellParser;

        public CommandParser(ISpellParser spellParser)
        {
            _spellParser = spellParser;
        }

        public bool Parse(Player player, string command)
        {
            return
                TryParseMovement(player, command) ||
                TryParseSingleWordCommands(player, command) ||
                TryParseMultiWordCommands(player, command);
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
                case "quit":
                case "exit": player.Quit(); return true;
                default: return false;
            }
        }

        private bool TryParseMultiWordCommands(Player player, string command)
        {
            var split = command.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            if (split.Length > 1)
            {
                var commandWord = split[0];
                var arguments = split[1];

                ITargetable? target;
                switch(commandWord)
                {
                    case "say":
                        player.Say(arguments); return true;
                    case "speak":
                        Speaking.TryParse(_spellParser, player, arguments, out Spell? spell);
                        player.Speak(spell);
                        return true;
                    case "rename":
                        player.Rename(arguments);
                        player.Echo($"You are now named {player.Description.ShortDesc}");
                        return true;
                    case "look":
                        target = Targeting.ResolveLocal(player, arguments);
                        player.Look(target);
                        return true;
                    case "point":
                        target = Targeting.ResolveLocal(player, arguments);
                        player.Point(target);
                        return true;
                    default:
                        return false;
                }
            }
            return false;
        }
    }
}
