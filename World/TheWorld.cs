namespace RunicMagic.World
{
    public class TheWorld
    {
        private static TheWorld _instance;

        public static TheWorld Instance {
            get {
                if (_instance == null) _instance = new TheWorld();
                return _instance;
            }
        }

        private TheWorld() {}

        public IRoom GetTheOnlyRoom()
        {
            throw new System.NotImplementedException();
        }
    }
}