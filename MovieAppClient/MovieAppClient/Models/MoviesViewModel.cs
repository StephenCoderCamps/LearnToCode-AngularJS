using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAppClient.Models
{
    public class MoviesViewModel
    {
        public IList<Movie> Movies { get; set; }
        public int TotalCount { get; set; }
    }
}