using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class Room : IRoom
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<IMobile> Entities { get; set; }

        public Room(string name, string description)
        {
            this.Name = name;
            this.Description = description;

            this.Entities = new List<IMobile>();
        }
    }
}
