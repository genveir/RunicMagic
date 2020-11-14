using System;
using System.Collections.Generic;

namespace RunicMagic.World {
    public interface IRoom 
    {
        string Name { get; }

        string Description { get; }

        IEnumerable<IMobile> Entities { get; }
    }

    public interface IPlayer : IMobile
    {
        string Look();

        void Cast(string spell);
    }

    public interface IMobile
    {
        string Name { get; }

        IRoom Location { get; }

        int Hitpoints { get; set; }
    }

    public interface ISpell
    {
        void Execute(IPlayer caster, object executor);
    }
}