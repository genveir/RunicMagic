using System.Collections.Generic;

namespace RunicMagic.World
{
    public class TheWorld : IWorld
    {
        private static TheWorld _instance;

        public static TheWorld Instance {
            get {
                if (_instance == null) _instance = new TheWorld();
                return _instance;
            }
        }

        public static void DestroyInstance()
        {
            _instance = null;
        }

        private TheWorld() {}

        public HashSet<IRoom> Rooms { get; }
    }
}