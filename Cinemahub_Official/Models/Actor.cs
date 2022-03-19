using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Name { get; set; }
        
        //[Required]
        public DateTime Birthday { get; set; }
        
        [StringLength(30, MinimumLength = 1)]
        [Required]
        public string Nationality { get; set; }
        public bool Status { get; set; }
        //public List<Award> Awards { get; set; }
        //public Movie[] Movies { get; set; }

        public Actor()
        {

        }
    }
}
