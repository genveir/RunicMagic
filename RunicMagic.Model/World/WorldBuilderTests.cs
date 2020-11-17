using RunicMagic.Model.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

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
            new CanonicalWorld().InitializeTheWorld();

            Assert.NotNull(TheWorld.Instance);
        }

        [Fact]
        public void InitializeTheWorldCreatesARoom()
        {
            new CanonicalWorld().InitializeTheWorld();

            Assert.True(TheWorld.Instance.Rooms.Count > 0);
        }

        [Fact]
        public void InitializeTheWorldAddsAPlayer()
        {
            new CanonicalWorld().InitializeTheWorld();

            Assert.NotNull(TheWorld.Instance.ThePlayer);
            Assert.Equal(10, TheWorld.Instance.ThePlayer.Hitpoints);
        }

        [Fact]
        public void IntitializeTheWorldAddsAnOrcInTheSameRoomAsThePlayer()
        {
            new CanonicalWorld().InitializeTheWorld();

            Assert.Contains(TheWorld.Instance.ThePlayer.Location.Entities, e => e.Name == "Orc" && e.Hitpoints == 10);
        }
    }
}
