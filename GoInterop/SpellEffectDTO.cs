using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoInterop
{
    public class SpellEffectDTO
    {
#nullable disable
        public string Type { get; set; }

        public dynamic PayLoad { get; set; }
#nullable enable
    }
}
