using System;
using System.Collections.Generic;
using System.Linq;
using World.Creatures;
using World.Plugins;

namespace World.Rooms
{
    public class Room
    {
        public long Id { get; set; }

        public List<Creature> Creatures { get; } = new List<Creature>();

        public Room?[] LinkedRooms { get; } = new Room?[6];

        public string Name { get; set; }
        public string Description { get; set; }

        public Room(string name, string description)
        {
            Name = name.Trim();
            Description = description.Trim();
        }

        public void LinkRoom(Room otherRoom, Direction direction, bool linkBack = true)
        {
            LinkedRooms[direction.Value] = otherRoom;
            if (linkBack) otherRoom.LinkRoom(this, direction.Opposite(), false);
        }

        public void Enter(Creature creature, Direction direction)
        {
            Creatures.Add(creature);
            this.CreatureEntered?.Invoke(this, creature, direction);
        }

        public void Exit(Creature creature, Direction direction)
        {
            Creatures.Remove(creature);
            this.CreatureExited?.Invoke(this, creature, direction);
        }

        public void PerformSay(Creature creature, string sentence)
        {
            this.CreatureSpoke?.Invoke(creature, sentence);
        }

        public void Echo(string message)
        {
            this.MessageBroadcast?.Invoke(message);
        }

        #region events

        public void SubscribePlayerToEvents(IPlayerWorldEventsHandler player)
        {
            this.CreatureEntered += player.CreatureEnteredRoom;
            this.CreatureExited += player.CreatureExitedRoom;
            
            this.CreatureSpoke += player.CreatureSpoke;

            this.MessageBroadcast += player.ReceivedBroadcastMessage;
        }

        public void UnsubscribePlayerFromEvents(IPlayerWorldEventsHandler player)
        {
            this.CreatureEntered -= player.CreatureEnteredRoom;
            this.CreatureExited -= player.CreatureExitedRoom;
            
            this.CreatureSpoke -= player.CreatureSpoke;

            this.MessageBroadcast -= player.ReceivedBroadcastMessage;
        }

        public delegate void CreatureMovementEventHandler(Room room, Creature creature, Direction direction);
        public event CreatureMovementEventHandler? CreatureEntered;
        public event CreatureMovementEventHandler? CreatureExited;

        public delegate void CreatureMessageEventHandler(Creature creature, string message);
        public event CreatureMessageEventHandler? CreatureSpoke;

        public delegate void BroadcastMessageHandler(string message);
        public event BroadcastMessageHandler? MessageBroadcast;

        #endregion

        public RoomCache RoomCache { get; } = new RoomCache();
    }
}