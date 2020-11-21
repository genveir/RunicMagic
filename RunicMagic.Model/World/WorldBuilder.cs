using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class WorldBuilder
    {
        private IWorld world;

        public WorldBuilder(IWorld world = null)
        {
            if (world == null) world = TheWorld.Instance;

            this.world = world;
        }

        public IRoom AddInitialRoom(string name, string description)
        {
            var initialRoom = new Room(name, description);
            world.Rooms.Add(initialRoom);

            return initialRoom;
        }

        public IRoom Build(IRoom room, Direction direction, string name, string description)
        {
            var newRoom = new Room(name, description);

            room.Link(newRoom, direction);

            return newRoom;
        }
    }
}
