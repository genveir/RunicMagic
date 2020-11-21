using RunicMagic.Domain;
using RunicMagic.Model.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class Room : IRoom
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<IMobile> Entities { get; set; }

        public ICollection<IItem> Items { get; set; }

        public Dictionary<Direction, IExit> Exits { get; }

        public Room(string name, string description)
        {
            this.Name = name;
            this.Description = description;

            this.Entities = new List<IMobile>();
            this.Items = new List<IItem>();
            this.Exits = new Dictionary<Direction, IExit>();
        }

        public void Link(IRoom room, Direction direction)
        {
            var exit = new Exit(this, room);
            this.Exits[direction] = exit;
            room.Exits[direction.Inverse()] = exit;
        }
    }
}
