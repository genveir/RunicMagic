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

        public string Prompt => DescriptorGenerators.GetPrompt(Player);

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

        public void SendOutput(string output)
        {
            DataAvailable?.Invoke(this, output);
        }

        public void Tick()
        {
            TickDone?.Invoke();
        }

        private bool disposed;
        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                Player.Dispose();

                WorldRunner.PlayerServices.Remove(this);
            }
        }

        public delegate Task TickEventHandler();
        public event TickEventHandler? TickDone;

        public delegate Task DataAvailableEventHandler(PlayerService sender, string data);
        public event DataAvailableEventHandler? DataAvailable;
    }
}
