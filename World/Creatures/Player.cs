using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Plugins;
using World.Rooms;

namespace World.Creatures
{
    public class Player : Creature
    {
        public string Name { get; set; }

        public Player(long id, string name, Room room) 
            : base(id, name, $"{name} is here.", room)
        {
            this.Name = name;
        }

        public void Move(Direction direction)
        {
            // should queue commands and let the server handle them, but for now this is instant
            var to = Location.LinkedRooms[direction.Value];
            if (to != null)
            {
                Location = to;
                OnValidMove?.Invoke(to, direction);
            }
            else OnInvalidMove?.Invoke();
        }

        public void Look()
        {
            OnLook?.Invoke(Location);
        }

        public void InvalidCommand(string command)
        {
            OnInvalidCommand?.Invoke(command);
        }

        public void SubscribeToEvents(IPlayerWorldEventsHandler eventHandler)
        {
            OnInvalidMove += eventHandler.TriedInvalidMove;
            OnValidMove += eventHandler.Moved;
            OnLook += eventHandler.Look;

            OnInvalidCommand += eventHandler.TriedInvalidCommand;

            Location.SubscribePlayerToEvents(eventHandler);
        }

        #region events

        public delegate void VoidEventHandler();
        public event VoidEventHandler? OnInvalidMove;

        public delegate void RoomDirectionEventHandler(Room room, Direction direction);
        public event RoomDirectionEventHandler? OnValidMove;

        public delegate void RoomEventHandler(Room room);
        public event RoomEventHandler? OnLook;

        public delegate void StringEventHandler(string value);
        public event StringEventHandler? OnInvalidCommand;
        #endregion
    }
}
