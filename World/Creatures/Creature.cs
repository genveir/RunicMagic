using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Rooms;

namespace World.Creatures
{
    public class Creature : ITargetable
    {
        public long Id { get; }
        public string[] TargetingKeywords { get; protected set; }

        public Room Location { get; set; }
        public Description Description { get; set; }

        public ITargetable? Target { get; set; }

        public Creature(long id, string[] targetingKeywords, string shortDesc, string longDesc, string lookDesc, Room location) 
        {
            TargetingKeywords = targetingKeywords;
            Id = id;
            Location = location;
            Description = new Description(shortDesc, longDesc, lookDesc);
        }

        public virtual void Initialize()
        {
            this.Location.Enter(this, Direction.From(-1));
        }

        public void Say(string sentence)
        {
            Location.PerformSay(this, sentence);
        }

        public virtual void Point(ITargetable? target)
        {
            if (target == null)
            {
                Target = null;
            }
            else
            {
                Location.PerformPoint(this, target);
                Target = target;
            }
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
