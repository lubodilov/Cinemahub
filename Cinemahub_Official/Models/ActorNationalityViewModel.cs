using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class ActorNationalityViewModel
    {
        public List<Actor>? Actors { get; set; }
        public SelectList? Nationality { get; set; }
        public string? ActorNationality { get; set; }
        public string? SearchString { get; set; }
    }
}
