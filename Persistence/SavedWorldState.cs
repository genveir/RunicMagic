using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Engine.Plugins;
using Microsoft.EntityFrameworkCore;
using Persistence.Models;
using World;
using World.Creatures;
using World.Magic;
using World.Magic.Runes;
using World.Objects;
using World.Rooms;

namespace Persistence
{
    public class SavedWorldState : IPersistedWorld
    {
        private readonly RunicMagicDbContext _context;

        internal SavedWorldState(IRunicMagicContextProvider contextProvider)
        {
            _context = contextProvider.Context;
        }

        public async Task<Room> GetStartingRoom() { 
            await CreateWorld(_context); // obviously this should not be necessary here.

            var mappedRooms = LoadArea(0);

            var secondRoom = mappedRooms.Single(r => r.Name == "The second room");

            secondRoom.Objects.Add(new RoomObject(0, TargetingKeywords.From("glowing", "rock"), "a glowing rock", "A glowing rock draws your attention.", @"
A giant glowing rock is standing in the middle of the room. Swirly
patterns of light fade in and out in complicated patterns.".TrimStart(), secondRoom));

            var casterCreator = new Player(0, "Castramus", secondRoom);
            secondRoom.Inscriptions.Add(new Inscription(0, TargetingKeywords.From("inscription"), "an inscription",
                "A magical inscription has been carved into the wall", $"The inscription reads\n\n\u001b[31;1mDEBUG\u001b[0m",
                RuneParser.ParseRunes(casterCreator, new[] { new DEBUG(casterCreator, secondRoom) }).Item1));

            return mappedRooms.Single(r => r.Name == "The starting room");
        }

        private List<Room> LoadArea(long areaId)
        {
            var area = _context.Rooms
                .Where(r => r.AreaId == areaId)
                .Include(r => r.Links)
                .ToList();

            var mappedRooms = Map(area);

            foreach(var room in area)
            {
                foreach(var link in room.Links)
                {
                    mappedRooms[room.RoomId].LinkedRooms[link.Direction] = mappedRooms[link.TargetId];
                }
            }

            return mappedRooms.Values.ToList();
        }

        private Dictionary<long, Room> Map(IEnumerable<RoomRecord> rooms) => rooms.Select(Map).ToDictionary(r => r.Id, r => r);
        private Room Map(RoomRecord roomRecord)
        {
            return new Room(roomRecord.RoomId, roomRecord.Name, roomRecord.RoomDesc);
        }

        private static async Task CreateWorld(RunicMagicDbContext context)
        {
            if (!context.Rooms.Any())
            {
                var startingRoom = new RoomRecord(0, "The starting room", @"
You are standing in a small room. It is quite nondistinct. It seems
like the gods have put a lot of effort into ensuring a world exists at
all, and not much into making it look nice. Surely they will do so
at a later point in time.".Trim());

                var secondRoom = new RoomRecord(0, "The second room", @"
You are standing in a small room. It is gray and dark, almost no light
penetrates through the solid rock. Frankly, it is amazing the light of
the gods reaches here at all. Then again: they are gods.".Trim());

                startingRoom.Links.Add(new RoomLinkRecord(startingRoom, secondRoom, Direction.NORTH.Value));
                secondRoom.Links.Add(new RoomLinkRecord(secondRoom, startingRoom, Direction.SOUTH.Value));

                context.Rooms.Add(startingRoom);
                context.Rooms.Add(secondRoom);

                await context.SaveChangesAsync();
            }
        }
    }
}