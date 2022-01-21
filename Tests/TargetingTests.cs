﻿using NUnit.Framework;
using World.Creatures;
using World.Magic;
using World.Magic.Runes;
using World.Rooms;

namespace Tests
{
    public class TargetingTests
    {
        [Test]
        public void CanSeeMyTargetIsAnInscription()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            var inscription = new Inscription(0, new[] { "ins" }, "ins", "ins", "ins", new Spellnode(new ZU(player, room)));

            player.Point(inscription);

            Inscription? result = null;
            player.Target?.ReferenceWhenTargeted.TryPickT2(out result, out _);

            Assert.IsNotNull(result);
        }

        [Test]
        public void CanSeeMyTargetIsNotAnInscription()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            player.Point(player);

            Inscription? result = null;
            player.Target?.ReferenceWhenTargeted.TryPickT2(out result, out _);

            Assert.IsNull(result);
        }
    }
}