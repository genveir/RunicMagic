using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class WorldBuilder
    {
        public IRoom AddInitialRoom(string name, string description)
        {
            var world = TheWorld.Instance;

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
