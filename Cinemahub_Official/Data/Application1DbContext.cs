using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinemahub_Official.Models;

namespace Cinemahub_Official.Data
{
    public class Application1DbContext : DbContext
    {
        public Application1DbContext (DbContextOptions<Application1DbContext> options)
            : base(options)
        {
        }

        public DbSet<Cinemahub_Official.Models.Movies> Movies { get; set; }
    }
}
