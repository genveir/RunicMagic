using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.World
{
    public class WorldBuilder
    {
        public void InitializeTheWorld()
        {
            var world = TheWorld.Instance;

            var theOnlyRoom = new Room("The Only Room", @"You are standing in The Room. It is a room. Not very distinct, nothing to distinguish it, even though it is unique.");
            world.Rooms.Add(theOnlyRoom);

            var thePlayer = new Player("The Only Player", theOnlyRoom);
        }
    }
}
