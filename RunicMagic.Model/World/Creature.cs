using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class Creature : IMobile
    {
        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public IRoom Location { get; set; }

        public int Hitpoints { get; set; }

        public Creature(string name, IRoom location)
        {
            this.Name = name;
            this.Location = location;

            location.Entities.Add(this);
        }
    }
}
