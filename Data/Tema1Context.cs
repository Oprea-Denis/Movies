using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tema1.Models;

namespace Tema1.Data
{
    public class Tema1Context : DbContext
    {
        public Tema1Context (DbContextOptions<Tema1Context> options)
            : base(options)
        {
        }

        public DbSet<Tema1.Models.Movie> Movie { get; set; }
    }
}
