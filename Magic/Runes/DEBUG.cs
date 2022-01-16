using World.Creatures;
using World.Rooms;

namespace Magic.Runes {
    public class DEBUG : Rune {
        public DEBUG(Player caster, Room room) : base(caster, room) {}

        public override (Spellnode, Rune[]) Parse(Rune[] runes) {
           return (null, null);
        }
	    public override object Eval(Spellnode sn) {
            var player = this.caster;
            player.Location.Echo($"{player.Description.ShortDesc} Debug!");
           return null;
       }

       public override bool IsEffect => true;
    }
}