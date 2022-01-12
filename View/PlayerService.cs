using Engine;
using Engine.Plugins;
using System.Collections.Generic;
using System.Threading.Tasks;
using World;
using World.Creatures;
using World.Rooms;

namespace View
{
    public class PlayerService : IPlayerService
    {
        private readonly Player _player;
        private readonly PlayerEventHandler _playerEventHandler;

        public PlayerService(PlayerFactory playerFactory)
        {
            _playerEventHandler = new PlayerEventHandler(this);
            _player = playerFactory.CreatePlayer();

            _player.SubscribeToEvents(_playerEventHandler);

            WorldRunner.Players.Add(this);
        }

        public List<string> Inputs { get; } = new List<string>();
        public async Task RegisterInput(string input) 
        {
            if (input == "n") _player.Move(Direction.NORTH);
            if (input == "e") _player.Move(Direction.EAST);
            if (input == "s") _player.Move(Direction.SOUTH);
            if (input == "w") _player.Move(Direction.WEST);
            if (input == "u") _player.Move(Direction.UP);
            if (input == "d") _player.Move(Direction.DOWN);

            if (input == "l") _playerEventHandler.Look(_player.Location);

            await Task.CompletedTask;
        }

        public delegate Task DataAvailableEventHandler(PlayerService sender, string data);
        public event DataAvailableEventHandler? DataAvailable;
        protected void RaiseDataAvailableEvent(string data)
        {
            DataAvailable?.Invoke(this, data);
        }

        public void SendOutput(string output)
        {
            RaiseDataAvailableEvent(output);
        }
    }
}
