using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;
using World.Rooms;

namespace World.Plugins
{
    public interface IPlayerWorldEventsHandler
    {
        void CreatureEnteredRoom(Room room, Creature creature, Direction enteredFrom);
        void CreatureExitedRoom(Room room, Creature creature, Direction leftTo);

        void CreatureSpoke(Creature creature, string message);
        void CreatureYelled(Creature creature, string message);

        void ReceivedBroadcastMessage(string message);
        
        void TriedInvalidMove();
        void Moved(Room to, Direction direction);
    }
}
