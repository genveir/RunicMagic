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
        public int HitPoints { get; set; } = 100;
        public int HitPointsMax { get; set; } = 100;
        public int HitPointsRegen { get; set; } = 5;

        public IPlayerWorldEventsHandler EventHandler { get; private set; } = null!; // haha booeee

        public Player(long id, string name, Room room) 
            : base(id, new[] { TargetingKeyword.From(name) }, name, $"{name} is here.", $"{name} looks very pretty.", room)
        {
            
        }

        public void Initialize(IPlayerWorldEventsHandler eventHandler)
        {
            EventHandler = eventHandler;

            SubscribeToEvents();

            base.Initialize();
        }

        public void Rename(string newName)
        {
            TargetingKeywords = new[] { TargetingKeyword.From(newName) };
            Description.ShortDesc = newName;
            Description.LongDesc = $"{newName} is here.";
            Description.LookDesc = $"{newName} looks very pretty!";
        }

        public override void Move(Direction direction)
        {
            var currentLocation = Location;

            if (CanMove(direction))
            {
                currentLocation.UnsubscribePlayerFromEvents(EventHandler);

                base.Move(direction);
                OnValidMove?.Invoke(Location, direction);

                Location.SubscribePlayerToEvents(EventHandler);
                
            }
            else
            {
                OnInvalidMove?.Invoke();
            }
        }

        public void Look(ITargetable? target)
        {
            if (target == null) Echo("You don't see that here!");
            else Echo(target.Description.LookDesc);
        }

        public override void Point(ITargetable? target)
        {
            if (target == null) Echo("You point at nothing!");
            base.Point(target);
        }

        // commands that just fire an event
        public void Look() => OnLook?.Invoke(Location);
        public void Quit() => OnQuit?.Invoke();
        public void InvalidCommand(string command) => OnInvalidCommand?.Invoke(command);
        public void Echo(string message) => OnEcho?.Invoke(message);

        public void Dispose()
        {
            Location.Exit(this, Direction.From(-1));

            UnsubscribeFromEvents();
        }

        public void SubscribeToEvents()
        {
            OnInvalidMove += EventHandler.TriedInvalidMove;
            OnValidMove += EventHandler.Moved;
            OnLook += EventHandler.Look;
            OnEcho += EventHandler.ReceivedBroadcastMessage;
            OnQuit += EventHandler.Quit;

            OnInvalidCommand += EventHandler.TriedInvalidCommand;

            Location.SubscribePlayerToEvents(EventHandler);
        }

        private void UnsubscribeFromEvents()
        {
            OnInvalidMove -= EventHandler.TriedInvalidMove;
            OnValidMove -= EventHandler.Moved;
            OnLook -= EventHandler.Look;
            OnEcho -= EventHandler.ReceivedBroadcastMessage;
            OnQuit -= EventHandler.Quit;

            OnInvalidCommand -= EventHandler.TriedInvalidCommand;

            Location.UnsubscribePlayerFromEvents(EventHandler);
        }

        #region events

        public delegate void RoomEventHandler(Room room);
        public event RoomEventHandler? OnLook;

        public delegate void StringEventHandler(string value);
        public event StringEventHandler? OnInvalidCommand;
        public event StringEventHandler? OnEcho;

        public delegate void VoidEventHandler();
        public event VoidEventHandler? OnInvalidMove;
        public event VoidEventHandler? OnQuit;

        public delegate void RoomDirectionEventHandler(Room room, Direction direction);
        public event RoomDirectionEventHandler? OnValidMove;

        #endregion

        #region Dispose Pattern
        private bool _disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    
                }

                _disposedValue = true;
            }
        }

        #endregion
    }
}
