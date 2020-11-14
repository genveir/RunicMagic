using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class Player : Creature
    {
        public Player(string name, IRoom location) : base(name, location)
        {

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
