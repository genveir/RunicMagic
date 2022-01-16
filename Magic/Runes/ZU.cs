using System.Collections.Generic;
using System.Linq;
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
            return (new Spellnode(this, new[] { arg }), remainder);
        }

        public override void Eval(Spellnode sn)
        {
            var arg = sn._children?.First();
            if (arg == null)
            {
                this.caster.Echo("Your spell fizzles!");
                return;
            }
            // TODO: rune.IsReference resolving to an effect
            if (!arg._rune.IsEffect)
            {
                this.caster.Echo("Your spell fizzles!");
                return;
            }
            arg.Eval();
        }

        public override bool IsCastable => true;
    }
}