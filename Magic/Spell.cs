using World.Creatures;

namespace Magic {
    public class Spell {
        public void cast(Player player) {
            player.Location.Echo($"{player.ShortDesc} Debug!");
        }
    }
}