using MovieAppServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAppServer.Views.Movies
{
    public class CreateViewModel
    {
        public Movie Movie { get; set; }
        public SelectList Categories { get; set; }
    }
}