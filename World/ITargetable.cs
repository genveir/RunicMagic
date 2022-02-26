using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using ValueOf;
using World.Creatures;
using World.Magic;
using World.Objects;

namespace World
{
    public interface ITargetable : IDescriptable
    {
        TargetingKeyword[] TargetingKeywords { get; }

        OneOf<Creature, RoomObject> ReferenceWhenTargeted { get; }
    }

    public static class TargetingKeywords
    {
        public static TargetingKeyword[] From(params string[] targetingKeywords) =>
            targetingKeywords.Select(t => TargetingKeyword.From(t)).ToArray();
    }

    public class TargetingKeyword : ValueOf<string, TargetingKeyword>
    {
        protected override void Validate()
        {
            Value = Value.ToLowerInvariant().Trim();
        }

        public bool StartsWith(string input) => Value.StartsWith(input);
    }
}
