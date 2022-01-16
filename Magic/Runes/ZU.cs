using System.Collections.Generic;
using World.Creatures;
using World.Rooms;

namespace Magic.Runes
{
    public class ZU : Rune
    {

        public ZU(Player caster, Room room) : base(caster, room) { }

        public override (Spellnode, IEnumerable<Rune>) Parse(Player player, IEnumerable<Rune> runes)
        {
            var (arg, remainder) = RuneParser.ParseRunes(player, runes);
            if (!arg._rune.IsReference && !arg._rune.IsEffect)
            {
                player.Echo("But nothing happens!");
                throw new RuneParseException("target of ZU cannot resolve to an effect");
            }
            return (new Spellnode(this, new Spellnode[] { arg }), remainder);
        }

        public override object Eval(Spellnode sn)
        {
            var arg = sn._children[0];
            if (arg == null)
            {
                this.caster.Echo("Your spell fizzles!");
                return null;
            }
            // TODO: rune.IsReference resolving to an effect
            if (!arg._rune.IsEffect)
            {
                this.caster.Echo("Your spell fizzles!");
                return null;
            }
            arg.Eval();
            return null;
        }

        public override bool IsCastable => true;
    }
}