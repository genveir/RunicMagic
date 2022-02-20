using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("RoomLink")]
    public class RoomLinkRecord
    {
        [Key]
        public long RoomLinkId { get; set; }

        [ForeignKey(nameof(Origin))]
        public long OriginId { get; set; }

        [ForeignKey(nameof(Target))]
        public long TargetId { get; set; }

        public int Direction { get; set; }

        public RoomRecord Origin { get; set; }
        public RoomRecord Target { get; set; }

#nullable disable
        public RoomLinkRecord() { }

        public RoomLinkRecord(RoomRecord origin, RoomRecord target, int direction)
        {
            this.Origin = origin;
            this.Target = target;
            this.Direction = direction;
        }
#nullable enable
    }
}
