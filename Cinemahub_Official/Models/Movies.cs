using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Director { get; set; }
        [Range(1,1000)]
        [Required]
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Movies()
        {

        }
    }
}
