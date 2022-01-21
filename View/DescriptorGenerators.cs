using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;
using World.Rooms;

namespace View
{
    public static class DescriptorGenerators
    {
        public static List<string> Look(Room room, Player player)
        {
            var header = $"[{ANSI_Colors.BrightCyan}{room.Name}{ANSI_Colors.Reset}]";
            var desc = room.Description;
            var creatures = DescribeCreatures(room, player);
            var roomObjects = DescribeRoomObjects(room);
            var exits = DescribeExits(room);

            return new List<string>()
                .Append(header)
                .Append(desc)
                .Concat(creatures)
                .Concat(roomObjects)
                .Append(exits)
                .ToList();
        }

        public static IEnumerable<string> DescribeCreatures(Room room, Player player)
        {
            List<string> descriptions = new();
            foreach(var creature in room.Creatures)
            {
                if (creature == player) continue;
                else
                {
                    descriptions.Add($"{ANSI_Colors.BrightMagenta}{creature.Description.LongDesc}{ANSI_Colors.Reset}");
                }
            }

            return descriptions;
        }

        public static IEnumerable<string> DescribeRoomObjects(Room room)
        {
            List<string> descriptions = new();
            foreach (var roomObject in room.Objects)
            {
                descriptions.Add($"{ANSI_Colors.BrightCyan}{roomObject.Description.LongDesc}{ANSI_Colors.Reset}");
            }

            return descriptions;
        }

        public static string DescribeExits(Room room)
        {
            if (room.RoomCache._exitString == null)
            {
                List<string> exitStrings = new();
                for (int dir = 0; dir < 6; dir++)
                {
                    if (room.LinkedRooms[dir] != null)
                    {
                        exitStrings.Add(Direction.From(dir).ExitDescriptor);
                    }
                }
                var exits = string.Join(" ", exitStrings);

                room.RoomCache._exitString = $"Exits: [{exits}]";
            }
            return room.RoomCache._exitString;
        }

        public static string GetPrompt(Player player)
        {
            var hp = $"{ANSI_Colors.Red}{player.HitPoints}{ANSI_Colors.Reset}";
            var maxHp = $"{ANSI_Colors.BrightRed}{player.HitPointsMax}{ANSI_Colors.Reset}";
            var regenColor = player.HitPointsRegen switch
            {
                < 0 => ANSI_Colors.BrightRed,
                0 => ANSI_Colors.BrightYellow,
                > 0 => ANSI_Colors.BrightGreen
            };
            var regenSign = player.HitPointsRegen switch
            {
                < 0 => "-",
                0 => "",
                > 0 => "+"
            };
            var hpRegen = $"{regenColor}{regenSign}{player.HitPointsRegen}{ANSI_Colors.Reset}";

            return $"{hp}/{maxHp} {hpRegen} >";
        }
    }
}
