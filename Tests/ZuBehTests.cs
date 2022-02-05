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
        public void ZuBehWithValidReference()
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
        public void ZuBehWithInvalidReferenceInscription()
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
        public void ZuBehWithInvalidReferenceType()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            player.Point(player);

            var spellstring = "ZU BEH";
            var parsed = new SpellParser().Parse(player, spellstring);

            if (parsed.IsError) Assert.Fail(parsed.Error);
            else Assert.IsNotNull(parsed.Result.root.Eval().Success);
        }

        [Test]
        public void ZuBehWithoutReference()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            var spellstring = "ZU BEH";
            var parsed = new SpellParser().Parse(player, spellstring);

            if (parsed.IsError) Assert.Fail(parsed.Error);
            else Assert.IsNotNull(parsed.Result.root.Eval().Success);
        }

        [Test]
        public void ZuDebug()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            var spellstring = "ZU DEBUG";
            var parsed = new SpellParser().Parse(player, spellstring);

            if (parsed.IsError) Assert.Fail(parsed.Error);
            else Assert.IsNotNull(parsed.Result.root.Eval());
        }

        [Test]
        public void ZuDebugDebug()
        {
            var room = new Room("room", "room");
            var player = new Player(0, "player", room);

            player.Point(player);

            var spellstring = "ZU DEBUG DEBUG";
            var parsed = new SpellParser().Parse(player, spellstring);

            Assert.IsTrue(parsed.IsError);
        }
    }
}