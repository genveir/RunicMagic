using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using World.Creatures;
using World.Magic;
using World.Rooms;

namespace World.Objects
{
    public class RoomObject : ITargetable
    {
        public long Id { get; }

        public Description Description { get; set; }

        public TargetingKeyword[] TargetingKeywords { get; set; }
        public OneOf<Creature, RoomObject> ReferenceWhenTargeted => this;

        public Room Location { get; set; }

        public RoomObject(long id, TargetingKeyword[] targetingKeywords, string shortDesc, string longDesc, string lookDesc, Room location)
        {
            Id = id;
            Description = new Description(shortDesc, longDesc, lookDesc);
            TargetingKeywords = targetingKeywords;
            Location = location;
        }
    }
}
