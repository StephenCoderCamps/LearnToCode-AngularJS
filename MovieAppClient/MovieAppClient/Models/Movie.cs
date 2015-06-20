using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAppClient.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }

        public int CategoryId { get; set; }

        //public Category Category { get; set; }

    }
}