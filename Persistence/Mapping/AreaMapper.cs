using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Models;
using World;
using World.Objects;
using World.Rooms;

namespace Persistence.Mapping
{
    internal class AreaMapper
    {
        public static List<Room> Map(IEnumerable<RoomRecord> area, IEnumerable<ObjectRecord> objects)
        {
            var mappedRooms = Map(area);
            var mappedObjects = Map(objects, mappedRooms);

            foreach (var room in area)
            {
                foreach (var link in room.Links)
                {
                    mappedRooms[room.RoomId].LinkedRooms[link.Direction] = mappedRooms[link.TargetId];
                }
            }

            foreach (var roomObject in mappedObjects.Values)
            {
                roomObject.Location.Objects.Add(roomObject);
            }

            return mappedRooms.Values.ToList();
        }

        private static Dictionary<long, Room> Map(IEnumerable<RoomRecord> rooms) =>
            rooms
                .Select(Map)
                .ToDictionary(r => r.Id, r => r);

        private static Room Map(RoomRecord roomRecord)
        {
            return new Room(roomRecord.RoomId, roomRecord.Name, roomRecord.RoomDesc);
        }

        private static Dictionary<long, RoomObject> Map(IEnumerable<ObjectRecord> objects, Dictionary<long, Room> rooms)
        {
            Dictionary<long, RoomObject> result = new();

            foreach (var objectRecord in objects)
            {
                var mapped = Map(objectRecord, rooms);
                if (mapped != null) result[mapped.Id] = mapped;
            }

            return result;
        }

        private static RoomObject? Map(ObjectRecord objectRecord, Dictionary<long, Room> rooms)
        {
            var targetingKeywords = objectRecord
                .TargetingKeywords
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Select(tk => TargetingKeyword.From(tk))
                .ToArray();

            if (rooms.TryGetValue(objectRecord.RoomId, out Room? room))
            {
                return new RoomObject(
                    objectRecord.ObjectId,
                    targetingKeywords,
                    objectRecord.Description.ShortDesc,
                    objectRecord.Description.LongDesc,
                    objectRecord.Description.LookDesc,
                    room);
            }
            else
            {
                return null;
            }
        }
    }
}
