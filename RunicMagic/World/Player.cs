using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class Player : Creature, IPlayer
    {
        private static IPlayer _player;

        public static IPlayer Instance { 
            get
            {
                return _player;
            } 
        }
        private Player(string name, IRoom location) : base(name, location) { }

        public static void Initialize(string name, IRoom location)
        {
            if (_player == null) _player = new Player(name, location);
            else throw new PlayerAlreadyInitializedException("Player was already initialized");
        }

        public static void DestroyInstance()
        {
            _player = null;
        }

        public void Cast(string spell)
        {
            throw new NotImplementedException();
        }

        public string Look()
        {
            throw new NotImplementedException();
        }
    }
}
