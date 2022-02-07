using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Room")]
    public class RoomRecord
    {
        [Key]
        public long RoomId { get; set; }

        [Required]
        public long AreaId { get; set; }

        [Required][MaxLength(80)]
        public string Name { get; set; }

        [Required][MaxLength(2048)]
        public string RoomDesc { get; set; }

        public ICollection<RoomLinkRecord> Links { get; set; }


#nullable disable
        public RoomRecord()
        {
            Links = new List<RoomLinkRecord>();
        }

        public RoomRecord(long areaId, string name, string roomDesc) : this()
        {
            this.AreaId = areaId;
            this.Name = name;
            this.RoomDesc = roomDesc;
        }
#nullable enable
    }
}
