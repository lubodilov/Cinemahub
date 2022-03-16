using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class Movies
    {
        [Key]
        public string Name { get; set; }
        public string Director { get; set; }
        public int Duration  { get; set; }
        public DateTime RealeaseDate { get; set; }
    }
}
