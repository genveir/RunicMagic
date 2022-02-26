using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedUtil;
using World.Magic;
using World.Magic.Effects;

namespace World.Plugins
{
    public interface IMagicHandler
    {
        public Task<ResultOrError<string>> GetAsText(Spell spell);

        public Task<ResultOrError<IEnumerable<ISpellEffect>?>> DoStep(Spell spell);
    }
}
