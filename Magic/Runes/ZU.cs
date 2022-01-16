using World.Creatures;
using World.Rooms;

namespace Magic.Runes {
    public class ZU : Rune {

        public ZU(Player caster, Room room) : base(caster, room) {}

        public override (Spellnode, Rune[]) Parse(Rune[] runes) {
           return (null, null);
        }
	    public override object Eval(Spellnode sn) {
           return null;
       }

       public override bool IsCastable => true;
    }
}