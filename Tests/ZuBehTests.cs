using Engine.Magic;
using NUnit.Framework;
using World;
using World.Creatures;
using World.Magic;
using World.Magic.Runes;
using World.Rooms;

namespace Tests
{
    public class ZuBehTests
    {
        [Test]
        public void ZuBehWithValidTarget()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            var inscription = new Inscription(0, TargetingKeywords.From("ins"), "ins", "ins", "ins", new RunePhrase(new DEBUG(player, room)));

            player.Point(inscription);

            var spellstring = "ZU BEH";
            var parsed = new SpellParser().Parse(player, spellstring);

            if (parsed.IsError) Assert.Fail(parsed.Error);
            else Assert.IsNotNull(parsed.Result.root.Eval());
        }

        [Test]
        public void ZuBehWithValidButInvalidTarget()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            var inscription = new Inscription(0, TargetingKeywords.From("ins"), "ins", "ins", "ins", new RunePhrase(new ZU(player, room)));

            player.Point(inscription);

            var spellstring = "ZU BEH";
            var parsed = new SpellParser().Parse(player, spellstring);

            if (parsed.IsError) Assert.Fail(parsed.Error);
            else Assert.IsNotNull(parsed.Result.root.Eval().Success);
        }

        [Test]
        public void ZuBehWithInvalidTarget()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            player.Point(player);

            var spellstring = "ZU BEH";
            var parsed = new SpellParser().Parse(player, spellstring);

            if (parsed.IsError) Assert.Fail(parsed.Error);
            else Assert.IsNotNull(parsed.Result.root.Eval().Success);
        }
    }
}