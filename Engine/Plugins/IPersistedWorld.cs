using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Rooms;

namespace Engine.Plugins
{
    public interface IPersistedWorld
    {
        Task<Room> GetStartingRoom();
    }
}
