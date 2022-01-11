using Engine;
using Engine.Plugins;
using System.Collections.Generic;
using System.Threading.Tasks;
using World;

namespace Runic_Magic.View
{
    public class PlayerService : IPlayerService
    {
        private readonly Player _player;

        private static int naamCounter = 0;
        public PlayerService()
        {
            this._player = new Player("Naam_" + naamCounter++);

            WorldRunner.Players.Add(this);
        }

        public List<string> Inputs { get; } = new List<string>();
        public async Task RegisterInput(string input) 
        {
            if (input == "whoami") SendOutput(_player.Name);

            if (_player.Name == input) SendOutput("wow dat is je naam!");
            this.Inputs.Add(input);

            await Task.CompletedTask;
        }

        public delegate void DataAvailableEventHandler(object sender, DataAvailableEventArgs e);
        public event DataAvailableEventHandler? DataAvailable;
        protected void RaiseDataAvailableEvent(string data)
        {
            DataAvailable?.Invoke(this, new DataAvailableEventArgs(data));
        }

        public void SendOutput(string output)
        {
            RaiseDataAvailableEvent(output);
        }
    }
}
