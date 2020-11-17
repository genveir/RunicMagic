using System;
using System.Collections.Generic;

namespace RunicMagic.Domain {
    public interface IWorld
    {
        HashSet<IRoom> Rooms { get; }
    }

    public enum Direction { North, East, South, West, Up, Down }

    public interface IRoom 
    {
        string Name { get; }

        string Description { get; }

        ICollection<IMobile> Entities { get; }

        Dictionary<Direction, IExit> Exits { get; }

        void Link(IRoom room, Direction direction);
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
    }

    public interface ICastResult
    {
        bool Success { get; }

        IEnumerable<IEffect> Effects { get; }
    }

    public interface IEffect { }

    public interface IMobile
    {
        string Name { get; }

        string ShortDesc { get; }

        IRoom Location { get; set; }

        int Hitpoints { get; set; }

        IEnumerable<IEffect> Move(Direction direction);
    }
}