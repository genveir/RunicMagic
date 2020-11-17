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

        IEnumerable<ISpellEffect> Effects { get; }
    }

    public interface ISpellEffect { }

    public interface IMobile
    {
        string Name { get; }

        string ShortDesc { get; }

        IRoom Location { get; }

        int Hitpoints { get; set; }
    }
}