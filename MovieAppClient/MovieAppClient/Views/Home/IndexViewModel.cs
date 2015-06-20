using MovieAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAppClient.Views.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.Category = new Category();
        }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public int PageCount { get; set; }
        public int CurrentPageIndex { get; set; }
    }
}