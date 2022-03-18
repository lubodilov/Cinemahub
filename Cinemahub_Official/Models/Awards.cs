using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class Awards
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Founded { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Location { get; set; }
        public string WebSite { get; set; }
        public Awards()
        {

        }

    }
}
