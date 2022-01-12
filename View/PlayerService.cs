using Engine;
using Engine.Plugins;
using System.Collections.Generic;
using System.Threading.Tasks;
using World;
using World.Creatures;
using World.Rooms;

namespace View
{
    public class PlayerService : IPlayerService, IDisposable
    {
        private readonly PlayerEventHandler _playerEventHandler;

        public Player Player { get; }

        public PlayerService(PlayerFactory playerFactory)
        {
            _playerEventHandler = new PlayerEventHandler(this);
            Player = playerFactory.CreatePlayer();

            Player.Initialize(_playerEventHandler);

            WorldRunner.PlayerServices.Add(this);
        }

        public Queue<string> Commands { get; } = new Queue<string>();
        public void RegisterInput(string input) 
        {
            Commands.Enqueue(input);
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

        public void Dispose()
        {
            Player.Dispose();

            WorldRunner.PlayerServices.Remove(this);
        }
    }
}
