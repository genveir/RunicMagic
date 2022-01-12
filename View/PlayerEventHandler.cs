using World.Creatures;
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

        public void Moved(Room to, Direction direction)
        {
            playerService.SendOutput($"you walked {direction.DepartureDescriptor}");
            this.Looked(to);
        }

        public void Looked(Room room)
        {
            playerService.SendOutput($"[\u001b[36;1m{room.Name}\u001b[0m]");
            playerService.SendOutput(room.Description);
            playerService.SendOutput(DescriptorGenerators.DescribeRoomExits(room));
        }
    }
}
