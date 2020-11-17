using RunicMagic.Domain;
using RunicMagic.Model.World;
using RunicMagic.World;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RunicMagic.Model.Spells.Tests
{
    public class ScenarioTests
    {
        [Fact]
        public void CanOpenTheDoorWithUntargetedSpell()
        {
            var builder = new WorldBuilder();

            var theRoom = builder.AddInitialRoom("testRoom", "");
            Player.Initialize("testPlayer", theRoom);

            builder.Build(theRoom, Direction.East, "anotherRoom", "");
            theRoom.Exits[Direction.East].Door = new Door() { Open = false };

            Player.Instance.Cast("ZU ALLEDUROPE");

            Assert.True(theRoom.Exits[Direction.East].Door.Open);
        }

        [Fact]
        public void CanOpenTheDoorWithTargetedSpell()
        {
            var builder = new WorldBuilder();

            var theRoom = builder.AddInitialRoom("testRoom", "");
            Player.Initialize("testPlayer", theRoom);

            builder.Build(theRoom, Direction.East, "anotherRoom", "");
            theRoom.Exits[Direction.East].Door = new Door() { Open = false };

            Player.Instance.IndicateTarget(theRoom.Exits[Direction.East].Door);
            Player.Instance.Cast("ZU DEZEDUROPE");

            Assert.True(theRoom.Exits[Direction.East].Door.Open);
        }
    }
}
