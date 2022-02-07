using Engine.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Creatures;

namespace Engine
{
    public class PlayerFactory
    {
        private readonly IPersistedWorld _persistedWorld;

        public PlayerFactory(IPersistedWorld persistedWorld)
        {
            _persistedWorld = persistedWorld;
        }

        public async Task<Player> CreatePlayer(string name)
        {
            var startingRoom = await _persistedWorld.GetStartingRoom();

            return new Player(0, name, startingRoom);
        }
    }
}
