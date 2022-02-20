using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Description")]
    public class DescriptionRecord
    {
        [Key]
        public long DescriptionId { get; set; }

        [Required]
        public string ShortDesc { get; set; }

        [Required]
        public string LongDesc { get; set; }

        [Required]
        public string LookDesc { get; set; }

#nullable disable
        public DescriptionRecord() { }

        public DescriptionRecord(string shortDesc, string longDesc, string lookDesc)
        {
            ShortDesc = shortDesc;
            LongDesc = longDesc;
            LookDesc = lookDesc;
        }
#nullable enable
    }
}
