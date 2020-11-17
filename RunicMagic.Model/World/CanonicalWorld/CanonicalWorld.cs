using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class CanonicalWorld
    {
        public void InitializeTheWorld()
        {
            var world = TheWorld.Instance;

            var theOnlyRoom = new Room("The Only Room", @"You are standing in The Room. It is a room. Not very distinct, nothing to distinguish it, even though it is unique.");
            world.Rooms.Add(theOnlyRoom);

            Player.Initialize("The Player", theOnlyRoom);
            Player.Instance.Hitpoints = 10;

            var orc = new Creature("Orc", theOnlyRoom);
            orc.Hitpoints = 10;
        }
    }
}
