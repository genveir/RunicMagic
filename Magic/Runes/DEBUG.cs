using World.Creatures;
using World.Rooms;

namespace Magic.Runes {
    public class DEBUG : Rune {
        public DEBUG(Player caster, Room room) : base(caster, room) {}

        public override (Spellnode, Rune[]) parse(Rune[] runes) {
           return (null, null);
        }
	    public override object eval(Spellnode sn) {
            var player = this.caster;
            player.Location.Echo($"{player.Description.ShortDesc} Debug!");
           return null;
       }

       public override bool isEffect => true;
    }
}