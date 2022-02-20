using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Object")]
    public class ObjectRecord
    {
        [Key]
        public long ObjectId { get; set; }

        [ForeignKey(nameof(Room))]
        public long RoomId { get; set; }

        [ForeignKey(nameof(Description))]
        public long DescriptionId { get; set; }

        [MaxLength(1280)]
        public string TargetingKeywords { get; set; }

        public RoomRecord Room { get; set; }

        public DescriptionRecord Description { get; set; }

#nullable disable
        public ObjectRecord() { }

        public ObjectRecord(RoomRecord room, string targetingKeywords, DescriptionRecord description)
        {
            Room = room;
            TargetingKeywords = targetingKeywords;
            Description = description;
        }
#nullable enable
    }
}
