using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Rooms;

namespace World.Creatures
{
    public class Creature : IDescriptable
    {
        public long Id { get; }

        public Room Location { get; set; }

        public Description Description { get; set; }

        public Creature(long id, string name, string shortDesc, string longDesc, string lookDesc, Room location) 
        {
            Id = id;
            Location = location;
            Description = new Description(name, shortDesc, longDesc, lookDesc);
        }

        public void Say(string sentence)
        {
            Location.PerformSay(this, sentence);
        }

        protected virtual bool CanMove(Direction direction) => Location.LinkedRooms[direction.Value] != null;
        public virtual void Move(Direction direction)
        {
            var to = Location.LinkedRooms[direction.Value];
            if (to != null)
            {
                Location.Exit(this, direction);

                Location = to;

                to.Enter(this, direction.Opposite());
            }
        }
    }
}
