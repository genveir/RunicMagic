using System;
using System.Collections.Generic;

namespace RunicMagic.Domain {
    public interface IWorld
    {
        HashSet<IRoom> Rooms { get; }
    }

    public interface IRoom 
    {
        string Name { get; }

        string Description { get; }

        ICollection<IMobile> Entities { get; }
    }

    public interface IPlayer : IMobile
    {
        string Look();

        void Cast(string spell);
    }

    public interface IMobile
    {
        string Name { get; }

        string ShortDesc { get; }

        IRoom Location { get; }

        int Hitpoints { get; set; }
    }
}