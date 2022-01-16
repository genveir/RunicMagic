using World.Creatures;
using World.Rooms;

namespace Magic.Runes {
    public class ZU : Rune {

        public ZU(Player caster, Room room) : base(caster, room) {}

        public override (Spellnode, Rune[]) parse(Rune[] runes) {
           return (null, null);
        }
	    public override object eval(Spellnode sn) {
           return null;
       }

       public override bool isCastable => true;
    }
}