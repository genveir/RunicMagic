﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OneOf;
using World.Creatures;
using World.Objects;

namespace World.Magic
{
    public class Inscription : ITargetable
    {
        public long Id { get; }

        public Description Description { get; }

        public TargetingKeyword[] TargetingKeywords { get; }
        public OneOf<Creature, RoomObject, Inscription> ReferenceWhenTargeted => this;

        public RunePhrase InscribedSpell;

        public Inscription(long id, TargetingKeyword[] targetingKeywords, string shortDesc, string longDesc, string lookDesc, RunePhrase inscribedSpell)
        {
            Id = id;
            TargetingKeywords = targetingKeywords;
            Description = new Description(shortDesc, longDesc, lookDesc);
            InscribedSpell = inscribedSpell;
        }
    }
}
