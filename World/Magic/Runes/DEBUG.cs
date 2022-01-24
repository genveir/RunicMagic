using System.Collections.Generic;
using System.Linq;
using OneOf;
using World.Creatures;
using World.Rooms;

namespace World.Magic.Runes
{
    public class DEBUG : Rune
    {
        public DEBUG(Player caster, Room room) : base(caster, room) { }

        public override OneOf<(RunePhrase, IEnumerable<Rune>), string> Parse(Player player, IEnumerable<Rune> runes)
        {
            return (new RunePhrase(this), runes.Skip(1));
        }
        public override EvalResult Eval(RunePhrase sn)
        {
            var player = this.caster;

            return EvalResult.SucceedWithAction(() => player.Location.Echo($"{player.Description.ShortDesc} Debug!"));
        }

        public override bool IsEffect => true;
    }
}