using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAppClient.Models
{
    public class Category
    {
        public Category()
        {
            this.Movies = new List<Movie>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

    }
}