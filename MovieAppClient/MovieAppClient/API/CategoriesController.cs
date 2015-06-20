using MovieAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieAppClient.API
{
    public class CategoriesController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IList<Category> Get()
        {
            return _db.Categories.ToList();
        }
    }
}
