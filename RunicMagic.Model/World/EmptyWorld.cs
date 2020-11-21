using RunicMagic.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunicMagic.Model.World
{
    public class EmptyWorld : IWorld
    {
        public EmptyWorld()
        {
            this.Rooms = new HashSet<IRoom>();
        }

        public HashSet<IRoom> Rooms { get; }

        public IPlayer ThePlayer { get; set; }
    }
}
