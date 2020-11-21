using System;
using System.Collections.Generic;

namespace RunicMagic.Domain {
    public interface IWorld
    {
        HashSet<IRoom> Rooms { get; }

        IPlayer ThePlayer { get; }
    }

    public enum Direction { North, East, South, West, Up, Down }

    public interface IRoom 
    {
        string Name { get; }

        string Description { get; }

        ICollection<IMobile> Entities { get; }

        ICollection<IItem> Items { get; }

        Dictionary<Direction, IExit> Exits { get; }

        void Link(IRoom room, Direction direction);
        object GetTarget(string name);
    }

    public interface IExit
    {
        IDoor Door { get; set; }

        (IRoom first, IRoom second) LinkedRooms { get; }

        bool IsBlocked();

        void Transport(IMobile mobile);
    }

    public interface IDoor
    {
        bool Open { get; set; }
    }

    public interface IPlayer : IMobile
    {
        object IndicatedTarget { get; }

        string Look();

        void IndicateTarget(object target);

        ICastResult Cast(string spell);

        void SetupOutput(Action<IEffect> outputFunc);
        void PushOutput(IEffect output);
    }

    public interface ICastResult
    {
        bool Success { get; }

        IEnumerable<IEffect> Effects { get; }
    }

    public interface IEffect 
    { 
        bool ShouldLook { get; }
    }

    public interface IMobile : IPowerSource
    {
        string Name { get; }

        string ShortDesc { get; }

        IRoom Location { get; set; }

        int Hitpoints { get; set; }

        bool ProtectedBy_BASDU_TI_OH { get; set; }

        IEnumerable<IEffect> Move(Direction direction);
    }

    public interface IItem
    {
        string Name { get; }
    }

    public interface IPowerSource
    {
        int CanTake();
        // returns the amount of points actually taken
        int Take(int n);
    }
}