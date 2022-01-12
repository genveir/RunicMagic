using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Rooms
{
    /// <summary>
    /// some fields with calculated fields you may want to cache on the room, so you don't have to look them up
    /// </summary>
    public class RoomCache
    {
        public string? _exitString;
    }
}
