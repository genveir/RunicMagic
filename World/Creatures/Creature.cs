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

        public virtual bool Move(Direction direction)
        {
            var to = Location.LinkedRooms[direction.Value];
            if (to != null)
            {
                Location.Exit(this, direction);

                Location = to;
                OnValidMove?.Invoke(to, direction);

                to.Enter(this, direction.Opposite());

                return true;
            }
            else
            {
                OnInvalidMove?.Invoke();

                return false;
            }
        }

        #region events

        public delegate void VoidEventHandler();
        public event VoidEventHandler? OnInvalidMove;

        public delegate void RoomDirectionEventHandler(Room room, Direction direction);
        public event RoomDirectionEventHandler? OnValidMove;


        #endregion
    }
}
