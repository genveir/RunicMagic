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
            var world = World.World.Instance;

            Assert.NotNull(world);
        }

        [Fact]
        public void WorldHasARoom()
        {
            var world = World.World.Instance;

            Assert.NotNull(world.GetTheOnlyRoom());
        }
    }
}
