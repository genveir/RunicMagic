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
        public static string DescribeRoomExits(Room room)
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
