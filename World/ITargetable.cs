using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using World.Creatures;
using World.Magic;
using World.Objects;

namespace World
{
    public interface ITargetable : IDescriptable
    {
        string[] TargetingKeywords { get; }

        OneOf<Creature, RoomObject, Inscription> ReferenceWhenTargeted { get; }
    }
}
