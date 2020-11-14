using RunicMagic.View;
using System;
using System.Collections.Generic;

namespace RunicMagic.World {
    
    public interface IModel
    {
        IWorld GetWorld();
        IPlayer GetPlayer();

        void ExecuteInput(IInput input);

        bool KeepRunning { get; }

        ICollection<string> Feedback { get; }
    }
    
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