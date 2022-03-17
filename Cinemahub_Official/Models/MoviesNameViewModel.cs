using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub_Official.Models
{
    public class MoviesNameViewModel
    {
        public List<Movies>? Movies { get; set; }
        //public SelectList? Name { get; set; }
        //public string? Name { get; set; }
        //public string? MovieName { get; set; }
        public string? SearchString { get; set; }
        public SelectList? Director { get; set; }
        public string? MovieDirector { get; set; }
        //public int Duration { get; set; }
        //public DateTime ReleaseDate { get; set; }
        //public MoviesNameViewModel()
        // {

        //}
    }
}
