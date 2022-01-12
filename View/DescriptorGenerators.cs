using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Rooms;

namespace View
{
    public static class DescriptorGenerators
    {
        public static List<string> Look(Room room)
        {
            var header = $"[\u001b[36;1m{room.Name}\u001b[0m]";
            var desc = room.Description;
            var creatures = DescribeCreatures(room);
            var exits = DescribeExits(room);

            return new List<string>()
                .Append(header)
                .Append(desc)
                .Concat(creatures)
                .Append(exits)
                .ToList();
        }

        public static IEnumerable<string> DescribeCreatures(Room room)
        {
            return room.Creatures.Select(c => c.LongDesc).Select(c => $"\u001b[35;1m{c}\u001b[0m");
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
    }
}
