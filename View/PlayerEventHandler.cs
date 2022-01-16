using System.Text;
using World;
using World.Creatures;
using World.Plugins;
using World.Rooms;

namespace View
{
    public class PlayerEventHandler : IPlayerWorldEventsHandler
    {
        private readonly PlayerService _playerService;

        public PlayerEventHandler(PlayerService playerService)
        {
            this._playerService = playerService;
        }

        public void CreatureEnteredRoom(Room room, Creature creature, Direction direction)
        {
            _playerService.SendOutput($"{creature.Description.ShortDesc} walked in {direction.ArrivalDescriptor}");
        }

        public void CreatureExitedRoom(Room room, Creature creature, Direction direction)
        {
            _playerService.SendOutput($"{creature.Description.ShortDesc} walked {direction.DepartureDescriptor}");
        }

        public void CreatureSpoke(Creature creature, string message)
        {
            if (creature == _playerService.Player)
            {
                _playerService.SendOutput($"you say `{message}`");
            }
            else _playerService.SendOutput($"{creature.Description.ShortDesc} says '{message}'");
        }

        public void CreaturePointed(Creature creature, ITargetable target)
        {
            StringBuilder result = new();

            if (creature == _playerService.Player) result.Append("You");
            else result.Append(creature.Description.ShortDesc);

            result.Append(" pointed at ");

            if (target == _playerService.Player) result.Append("YOU");
            else result.Append(target.Description.ShortDesc);

            _playerService.SendOutput(result.ToString());
        }

        public void ReceivedBroadcastMessage(string message)
        {
            _playerService.SendOutput(message);
        }

        public void TriedInvalidMove()
        {
            _playerService.SendOutput("you bumped into the wall. Ouch!");
        }

        public void TriedInvalidCommand(string command)
        {
            _playerService.SendOutput($"I don't know what '{command}' means!");
        }

        public void Moved(Room to, Direction direction)
        {
            _playerService.SendOutput($"you walked {direction.DepartureDescriptor}");

            Look(to);
        }

        public void Look(Room room)
        {
            var lookData = DescriptorGenerators.Look(room, _playerService.Player);

            foreach (var line in lookData) _playerService.SendOutput(line);
        }

        public void Quit()
        {
            _playerService.SendOutput("Thanks for playing!");

            _playerService.Dispose();
        }
    }
}
