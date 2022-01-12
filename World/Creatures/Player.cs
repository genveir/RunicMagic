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

        public IPlayerWorldEventsHandler EventHandler { get; private set; } = null!; // haha booeee

        public Player(long id, string name, Room room) 
            : base(id, name, $"{name} is here.", room)
        {
            this.Name = name;
        }

        public void Look()
        {
            OnLook?.Invoke(Location);
        }

        public void InvalidCommand(string command)
        {
            OnInvalidCommand?.Invoke(command);
        }

        public void Echo(string message)
        {
            OnEcho?.Invoke(message);
        }

        public void SubscribeToEvents(IPlayerWorldEventsHandler eventHandler)
        {
            EventHandler = eventHandler;

            OnInvalidMove += EventHandler.TriedInvalidMove;
            OnValidMove += EventHandler.Moved;
            OnLook += EventHandler.Look;
            OnEcho += EventHandler.ReceivedBroadcastMessage;

            OnInvalidCommand += EventHandler.TriedInvalidCommand;

            Location.Enter(this, Direction.From(-1));
        }

        public override bool Move(Direction direction)
        {
            var currentLocation = Location;

            var moved = base.Move(direction);

            if (moved)
            {
                currentLocation.UnsubscribePlayerFromEvents(EventHandler);
                Location.SubscribePlayerToEvents(EventHandler);
            }

            return moved;
        }

        #region events

        public delegate void RoomEventHandler(Room room);
        public event RoomEventHandler? OnLook;

        public delegate void StringEventHandler(string value);
        public event StringEventHandler? OnInvalidCommand;
        public event StringEventHandler? OnEcho;
        #endregion
    }
}
