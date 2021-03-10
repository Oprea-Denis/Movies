using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tema1.Models
{
    public class Movie
    {

        public Guid id { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public int year { get; set; }
        public int imdbRating { get; set; }

    }
}
