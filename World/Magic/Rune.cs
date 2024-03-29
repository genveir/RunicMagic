using System.Collections.Generic;
using OneOf;
using SharedUtil;
using World.Creatures;
using World.Plugins;
using World.Rooms;
using System.Linq;

namespace World.Magic
{
    public abstract class Rune
    {
        protected Player caster;
        protected Room room;
        public RuneType[] type {get;}

        protected Rune(Player caster, Room room, params RuneType[] type)
        {
            this.caster = caster;
            this.room = room;
            this.type = type;
        }

        public abstract ResultOrError<(RunePhrase, IEnumerable<Rune>)> Parse(ISpellParser parser, Player player, IEnumerable<Rune> remainder);
        public abstract EvalResult Eval(RunePhrase sn);

        public RuneType ResultType()
        {
            return this.type.Last();
        }

    }
}