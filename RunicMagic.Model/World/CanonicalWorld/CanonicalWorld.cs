using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class CanonicalWorld : World
    {
        public CanonicalWorld() : base()
        {
            InitializeTheWorld();
        }

        public void InitializeTheWorld()
        {
            var builder = new WorldBuilder(this);

            var theFirstRoom = builder.AddInitialRoom("The First Room", @"You are standing in The First Room. It is a room. Not very distinct, nothing to distinguish it, even though it is unique.");
            builder.Build(theFirstRoom, Direction.East, "The Second Room", @"
Where at first your world was small, you were afraid, you were petrified alone in the dark,
now you know you will survive. Because you have opened a door and moved, and life is good. ".Trim());

            theFirstRoom.Exits[Direction.East].Door = new Door() { Open = false };

            this.ThePlayer = new Player("The Player", theFirstRoom);
            this.ThePlayer.Hitpoints = 10;

            var sheep = new Creature("Sheep", theFirstRoom);
            sheep.ShortDesc = "A sheep is walking around, bleating merrily";
            sheep.Hitpoints = 10;
        }
    }
}
