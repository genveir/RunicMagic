using RunicMagic.Model.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace RunicMagic.Model.World
{
    public class CanonicalWorldTests
    {
        private CanonicalWorld world;
        public CanonicalWorldTests()
        {
            this.world = new CanonicalWorld();
        }

        [Fact]
        public void InitializeTheWorldCreatesAWorld()
        {
            world.InitializeTheWorld();

            Assert.NotNull(world);
        }

        [Fact]
        public void InitializeTheWorldCreatesARoom()
        {
            world.InitializeTheWorld();

            Assert.True(world.Rooms.Count > 0);
        }

        [Fact]
        public void InitializeTheWorldAddsAPlayer()
        {
            world.InitializeTheWorld();

            Assert.NotNull(world.ThePlayer);
            Assert.Equal(10, world.ThePlayer.Hitpoints);
        }

        [Fact]
        public void IntitializeTheWorldAddsASheepInTheSameRoomAsThePlayer()
        {
            world.InitializeTheWorld();

            Assert.Contains(world.ThePlayer.Location.Entities, e => e.Name == "Sheep" && e.Hitpoints == 10);
        }
    }
}
