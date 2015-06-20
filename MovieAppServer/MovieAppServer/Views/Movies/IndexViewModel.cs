using MovieAppServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAppServer.Views.Movies
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.Category = new Category();
        }

        public SelectList Categories { get; set; }
        public Category Category { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}