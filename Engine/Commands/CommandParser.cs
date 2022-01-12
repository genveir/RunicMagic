﻿using Runes;
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

                switch(commandWord)
                {
                    case "say":
                        player.Say(arguments); return true;
                    case "cast":
                        ParseCast(player, arguments); return true;
                    case "rename":
                        player.Name = arguments;
                        player.ShortDesc = player.Name;
                        player.LongDesc = $"{player.Name} is here.";
                        return true;
                    default:
                        return false;
                }
            }
            return false;
        }

        private static void ParseCast(Player player, string spell)
        {
            var parser = new RuneParser(player);

            parser.Parse(spell);
        }
    }
}
