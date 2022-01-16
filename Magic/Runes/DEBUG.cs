using System.Collections.Generic;
using System.Linq;
using World.Creatures;
using World.Rooms;

namespace Magic.Runes
{
    public class DEBUG : Rune
    {
        public DEBUG(Player caster, Room room) : base(caster, room) { }

        public override (Spellnode, IEnumerable<Rune>) Parse(Player player, IEnumerable<Rune> runes)
        {
            return (new Spellnode(this), runes.Skip(1));
        }
        public override EvalResult Eval(Spellnode sn)
        {
            var player = this.caster;

            return EvalResult.SucceedWithAction(() => player.Location.Echo($"{player.Description.ShortDesc} Debug!"));
        }

        public override bool IsEffect => true;
    }
}