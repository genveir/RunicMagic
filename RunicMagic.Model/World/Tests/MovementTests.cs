using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RunicMagic.Model.World.Tests
{
    public class MovementTests
    {
        public MovementTests()
        {
            Player.DestroyInstance();
        }

        [Fact]
        public void CanMoveFromOneRoomToTheOther()
        {
            var builder = new WorldBuilder();
            var testRoom = builder.AddInitialRoom("testRoom", "");

            var newRoom = builder.Build(testRoom, Direction.East, "newRoom", "");

            Player.Initialize("player", testRoom);
            Player.Instance.Move(Direction.East);

            Assert.Equal(newRoom, Player.Instance.Location);
        }
    }
}
