using RunicMagic.Domain;
using RunicMagic.Model.World;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RunicMagic.Model.Spells.Tests
{
    public class ScenarioTests
    {
        public ScenarioTests()
        {
            TheWorld.DestroyInstance();
            Player.DestroyInstance();
        }

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

        [Fact]
        public void SpellCanTakeFromPowerSource()
        {
            var builder = new WorldBuilder();

            var theRoom = builder.AddInitialRoom("testRoom", "");
            Player.Initialize("testPlayer", theRoom);
            Player.Instance.Hitpoints = 100;

            var sheep = new Mobile("Sheep", theRoom);
            sheep.Hitpoints = 50;

            var fire = new Fire(10, theRoom);

            Player.Instance.Cast("ZU DURERUNE");

            Assert.Equal(0, fire.PowerPoints);
            Assert.Equal(17, sheep.Hitpoints);
            Assert.Equal(100, Player.Instance.Hitpoints);
        }
    }
}
