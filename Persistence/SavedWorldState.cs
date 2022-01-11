using Engine.Plugins;
using World.Rooms;

namespace Peristence
{
    public class SavedWorldState : IPersistedWorld
    {
        public Room StartingRoom { get; }

        public SavedWorldState()
        {
            this.StartingRoom = new Room("The starting room", @"
You are standing in a small room. It is quite nondistinct. It seems
like the gods have put a lot of effort into ensuring a world exists at
all, and not much into making it look nice. Surely they will do so
at a later point in time.");

            var secondRoom = new Room("The second room", @"
You are standing in a small room. It is gray and dark, almost no light
penetrates through the solid rock. Frankly, it is amazing the light of
the gods reaches here at all. Then again: they are gods.");

            StartingRoom.LinkRoom(secondRoom, Direction.NORTH);
        }
    }
}