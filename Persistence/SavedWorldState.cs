using Engine.Plugins;
using World.Objects;
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

            secondRoom.Objects.Add(new RoomObject(0, new[] {"glowing","rock"}, "a glowing rock", "A glowing rock draws your attention.", @"
A giant glowing rock is standing in the middle of the room. Swirly
patterns of light fade in and out in complicated patterns.".TrimStart(), secondRoom));

            StartingRoom.LinkRoom(secondRoom, Direction.NORTH);
        }
    }
}