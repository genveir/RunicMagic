using Engine;
using NUnit.Framework;
using Peristence;
using View;
using World.Creatures;

namespace World.Tests
{
    public class PlayerDisposalTest
    {
        [Test]
        public void PlayerHasReferencesAfterCreation()
        {
            var factory = new PlayerFactory(new SavedWorldState());
            var playerService = new PlayerService(factory);
            var player = playerService.Player;

            WeakReference playerRef = new WeakReference(player);
            player = null;

            GC.Collect();

            Assert.That(playerRef.IsAlive);
        }

        [Test]
        public void PlayerHasNoReferencesAfterQuit()
        {
            var factory = new PlayerFactory(new SavedWorldState());
            var playerService = new PlayerService(factory);
            var player = playerService.Player;

            playerService.Dispose();
            playerService = null;

            WeakReference playerRef = new WeakReference(player);
            player = null;

            GC.Collect();

            Assert.That(!playerRef.IsAlive);
        }
    }
}