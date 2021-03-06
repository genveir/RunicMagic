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
        [Fact]
        public void CanOpenTheDoorWithUntargetedSpell()
        {
            var world = new World.EmptyWorld();
            var builder = new WorldBuilder(world);

            var theRoom = builder.AddInitialRoom("testRoom", "");
            world.ThePlayer = new Player("testPlayer", theRoom);
            world.ThePlayer.Hitpoints = 100;

            builder.Build(theRoom, Direction.East, "anotherRoom", "");
            theRoom.Exits[Direction.East].Door = new Door() { Open = false };

            world.ThePlayer.Cast("ZU ALLEDUROPE");

            Assert.True(theRoom.Exits[Direction.East].Door.Open);
        }

        [Fact]
        public void CanOpenTheDoorWithTargetedSpell()
        {
            var world = new World.EmptyWorld();
            var builder = new WorldBuilder(world);

            var theRoom = builder.AddInitialRoom("testRoom", "");
            world.ThePlayer = new Player("testPlayer", theRoom);
            world.ThePlayer.Hitpoints = 100;

            builder.Build(theRoom, Direction.East, "anotherRoom", "");
            theRoom.Exits[Direction.East].Door = new Door() { Open = false };

            world.ThePlayer.IndicateTarget(theRoom.Exits[Direction.East].Door);
            world.ThePlayer.Cast("ZU DEZEDUROPE");

            Assert.True(theRoom.Exits[Direction.East].Door.Open);
        }
        
        [Fact]
        public void SpellCanTakeFromPowerSource()
        {
            var world = new World.EmptyWorld();
            var builder = new WorldBuilder(world);

            var theRoom = builder.AddInitialRoom("testRoom", "");
            world.ThePlayer = new Player("testPlayer", theRoom);
            world.ThePlayer.Hitpoints = 100;
            world.ThePlayer.ProtectedBy_BASDU_TI_OH = true;

            var sheep = new Mobile("Sheep", theRoom);
            sheep.Hitpoints = 50;

            var fire = new Fire(10, theRoom);

            var castresult = world.ThePlayer.Cast("ZU DURERUNE");
            Assert.True(castresult.Success);

            Assert.Equal(100, world.ThePlayer.Hitpoints);
            Assert.Equal(0, fire.PowerPoints);
            Assert.Equal(17, sheep.Hitpoints);
        }
    }
}
