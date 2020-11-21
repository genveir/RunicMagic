using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RunicMagic.Model.World.Tests
{
    public class MovementTests
    {
        [Fact]
        public void CanMoveFromOneRoomToTheOther()
        {
            var world = new EmptyWorld();

            var builder = new WorldBuilder(world);
            var testRoom = builder.AddInitialRoom("testRoom", "");

            var newRoom = builder.Build(testRoom, Direction.East, "newRoom", "");

            world.ThePlayer = new Player("player", testRoom);
            world.ThePlayer.Move(Direction.East);

            Assert.Equal(newRoom, world.ThePlayer.Location);
        }
    }
}
