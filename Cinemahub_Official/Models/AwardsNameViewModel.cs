using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class AwardsNameViewModel
    {
        public List<Awards>? Awards { get; set; }
        public string? SearchString { get; set; }
        public SelectList? Location { get; set; }
        public string? AwardLocation { get; set; }
    }
}
