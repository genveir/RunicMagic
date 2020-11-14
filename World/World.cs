namespace RunicMagic.World 
{
    public class World
    {
        private static World _instance;

        public static World Instance {
            get {
                if (_instance == null) _instance = new World();
                return _instance;
            }
        }

        private World() {}

        public IRoom GetTheOnlyRoom()
        {
            throw new System.NotImplementedException();
        }
    }
}