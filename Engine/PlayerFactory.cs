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

        public Player CreatePlayer()
        {
            return new Player(0, "Naam", _persistedWorld.StartingRoom);
        }
    }
}
