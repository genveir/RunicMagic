using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Domain
{
    public static class DirectionUtil
    {
        public static Direction Inverse(this Direction direction)
        {
            switch(direction)
            {
                case Direction.North: return Direction.South;
                case Direction.East: return Direction.West;
                case Direction.South: return Direction.North;
                case Direction.West: return Direction.East;
                case Direction.Up: return Direction.Down;
                case Direction.Down: return Direction.Up;
                default: throw new NotImplementedException();
            }
        }
    }
}
