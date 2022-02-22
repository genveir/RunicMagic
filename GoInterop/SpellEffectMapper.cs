using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Magic.Effects;

namespace GoInterop
{
    internal class SpellEffectMapper
    {
        public static IEnumerable<ISpellEffect> MapEffects(IEnumerable<SpellEffectDTO> dtos) => dtos.Select(MapEffect);
        
        public static ISpellEffect MapEffect(SpellEffectDTO dto)
        {
            return dto.Type switch
            {
                "Echo" => new Echo(dto.PayLoad),
                "DamageCaster" => new DamageCaster(long.Parse(dto.PayLoad)),
                _ => new Echo($"unable to parse this effect type: {dto.Type}"),
            };
        }
        
    }
}
