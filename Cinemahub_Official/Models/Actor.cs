using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Nationality { get; set; }
        public bool Status { get; set; }
        //public List<Award> Awards { get; set; }
        //public Movie[] Movies { get; set; }

        public Actor()
        {

        }
    }
}
