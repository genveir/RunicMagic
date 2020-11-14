using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RunicMagic.World
{
    public class WorldBuilderTests
    {
        public WorldBuilderTests()
        {
            TheWorld.DestroyInstance();
            Player.DestroyInstance();
        }

        [Fact]
        public void InitializeTheWorldCreatesAWorld()
        {
            new WorldBuilder().InitializeTheWorld();

            Assert.NotNull(TheWorld.Instance);
        }

        [Fact]
        public void InitializeTheWorldCreatesARoom()
        {
            new WorldBuilder().InitializeTheWorld();

            Assert.True(TheWorld.Instance.Rooms.Count > 0);
        }

        [Fact]
        public void InitializeTheWorldAddsAPlayer()
        {
            new WorldBuilder().InitializeTheWorld();

            Assert.NotNull(TheWorld.Instance.ThePlayer);
        }
    }
}
