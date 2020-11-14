using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RunicMagic
{
    public class Tests
    {
        [Fact]
        public void CanConstructWorld() 
        {
            var world = TheWorld.Instance;

            Assert.NotNull(world);
        }

        [Fact]
        public void WorldHasARoom()
        {
            var world = TheWorld.Instance;

            Assert.True(world.Rooms.Count > 0);
        }
    }
}
