﻿using World.Creatures;
using World.Plugins;
using World.Rooms;

namespace View
{
    public class PlayerEventHandler : IPlayerWorldEventsHandler
    {
        private readonly PlayerService playerService;

        public PlayerEventHandler(PlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void CreatureEnteredRoom(Room room, Creature creature, Direction direction)
        {
            playerService.SendOutput($"{creature.ShortDesc} walked in {direction.ArrivalDescriptor}");
        }

        public void CreatureExitedRoom(Room room, Creature creature, Direction direction)
        {
            playerService.SendOutput($"{creature.ShortDesc} walked {direction.DepartureDescriptor}");
        }

        public void CreatureSpoke(Creature creature, string message)
        {
            playerService.SendOutput($"{creature.ShortDesc} says '{message}'");
        }

        public void ReceivedBroadcastMessage(string message)
        {
            playerService.SendOutput(message);
        }

        public void TriedInvalidMove()
        {
            playerService.SendOutput("you bumped into the wall. Ouch!");
        }

        public void TriedInvalidCommand(string command)
        {
            playerService.SendOutput($"I don't know what '{command}' means!");
        }

        public void Moved(Room to, Direction direction)
        {
            playerService.SendOutput($"you walked {direction.DepartureDescriptor}");

            Look(to);
        }

        public void Look(Room room)
        {
            var lookData = DescriptorGenerators.Look(room);

            foreach (var line in lookData) playerService.SendOutput(line);
        }
    }
}
