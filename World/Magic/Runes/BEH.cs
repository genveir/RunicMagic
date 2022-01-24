using System.Collections.Generic;
using System.Linq;
using World.Creatures;
using World.Rooms;

namespace World.Magic.Runes
{
    public class BEH : Rune
    {
        public BEH(Player caster, Room room) : base(caster, room) { }

        public override (RunePhrase, IEnumerable<Rune>) Parse(Player player, IEnumerable<Rune> runes)
        {
            return (new RunePhrase(this), runes.Skip(1));
        }
        public override EvalResult Eval(RunePhrase sn)
        {
            var player = this.caster;
            return EvalResult.Succeed(player.Target);
        }

        public override bool IsReference => true;
    }
}