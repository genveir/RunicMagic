using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World;
using World.Creatures;

namespace Engine.Commands
{
    public static class Targeting
    {
        public static ITargetable? ResolveLocal(Player player, string targetingInfo)
        {
            var targetWords = targetingInfo
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToLower());

            targetWords = targetWords
                .Select(word => (word == "self" || word == "me") ? player.TargetingKeywords[0].Value : word)
                .ToArray();

            var possibleTargets = new List<ITargetable>();
            possibleTargets.AddRange(player.Location.Creatures);
            possibleTargets.AddRange(player.Location.Objects);
            possibleTargets.AddRange(player.Location.Inscriptions);

            foreach (var target in possibleTargets)
            {
                if (targetWords.All(word => target.TargetingKeywords.Any(t => t.StartsWith(word)))) return target;
            }
            return null;
        }
    }
}
