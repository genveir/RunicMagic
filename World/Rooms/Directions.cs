using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace World.Rooms
{
    public class Direction : ValueOf<int, Direction>
    {
        public static Direction NORTH { get; } = From(0);
        public static Direction EAST { get; } = From(1);
        public static Direction SOUTH { get; } = From(2);
        public static Direction WEST { get; } = From(3);
        public static Direction UP { get; } = From(4);
        public static Direction DOWN { get; } = From(5);
        
        public string ArrivalDescriptor =>
            Value switch
            {
                0 => "from the north",
                1 => "from the east",
                2 => "from the south",
                3 => "from the west",
                4 => "from above",
                5 => "from below",
                _ => "out of thin air"
            };

        public string DepartureDescriptor =>
            Value switch
            {
                0 => "north",
                1 => "east",
                2 => "south",
                3 => "west",
                4 => "up",
                5 => "down",
                _ => "into thin air"
            };

        public string ExitDescriptor =>
            Value switch
            {
                0 => "North",
                1 => "East",
                2 => "South",
                3 => "West",
                4 => "Up",
                5 => "Down",
                _ => "In a mysterious direction"
            };

        public Direction Opposite() =>
            Value switch
            {
                0 => From(2),
                1 => From(3),
                2 => From(0),
                3 => From(1),
                4 => From(5),
                5 => From(4),
                _ => throw new NotImplementedException($"unknown direction {Value}")
            };
    }
}
