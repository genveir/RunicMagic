using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
using World.Creatures;
using World.Rooms;

namespace Engine.Commands
{
    public static class CommandParser
    {
        public static bool Parse(Player player, string command)
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

        private static bool TryParseMultiWordCommands(Player player, string command)
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
                    case "cast":
                        ParseCast(player, arguments); return true;
                    case "rename":
                        player.Rename(arguments);
                        player.Echo($"You are now named {player.Description.ShortDesc}");
                        return true;
                    case "look":
                        target = ResolveLocalTarget(player, arguments);
                        player.Look(target);
                        return true;
                    case "point":
                        target = ResolveLocalTarget(player, arguments);
                        player.Point(target);
                        return true;
                    default:
                        return false;
                }
            }
            return false;
        }

        private static ITargetable? ResolveLocalTarget(Player player, string targetingInfo)
        {
            var targetWords = targetingInfo
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            targetWords = targetWords
                .Select(word => (word == "self" || word == "me") ? player.TargetingKeywords[0] : word)
                .ToArray();

            var possibleTargets = new List<ITargetable>();
            possibleTargets.AddRange(player.Location.Creatures);
            possibleTargets.AddRange(player.Location.Objects);

            foreach (var target in possibleTargets)
            {
                if (targetWords.All(word => target.TargetingKeywords.Any(t => t.StartsWith(word)))) return target;
            }
            return null;
        }

        private static void ParseCast(Player player, string spellstring)
        {
            RuneParser.Parse(player, spellstring)?.Cast(player);
        }
    }
}
