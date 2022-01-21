using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Rooms;

namespace World.Objects
{
    public class RoomObject : ITargetable
    {
        public long Id { get; }

        public Description Description { get; set; }

        public string[] TargetingKeywords { get; set; }

        public Room Location { get; set; }

        public RoomObject(long id, string[] targetingKeywords, string shortDesc, string longDesc, string lookDesc, Room location)
        {
            Id = id;
            Description = new Description(shortDesc, longDesc, lookDesc);
            TargetingKeywords = targetingKeywords;
            Location = location;
        }
    }
}
