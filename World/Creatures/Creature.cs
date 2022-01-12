using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Rooms;

namespace World.Creatures
{
    public class Creature
    {
        public long Id { get; }

        public Room Location { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public Creature(long id, string shortDesc, string longDesc, Room location)
        {
            Id = id;
            ShortDesc = shortDesc;
            LongDesc = longDesc;
            Location = location;
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
