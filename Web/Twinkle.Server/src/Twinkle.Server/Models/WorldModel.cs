using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Twinkle.Server.Models
{
    public class WorldModel
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string WorldId { get; set; }

        public string DataBlob { get; set; }
    }
}
