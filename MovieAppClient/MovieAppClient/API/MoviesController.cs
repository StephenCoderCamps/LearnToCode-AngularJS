using MovieAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieAppClient.Views.Home;
using System.Data.Entity;


namespace MovieAppClient.API
{
    public class MoviesController : ApiController
    {
        const int PAGE_SIZE = 5;

        private ApplicationDbContext _db = new ApplicationDbContext();

        public MoviesViewModel Get(int categoryId, int pageIndex = 0) {
            return new MoviesViewModel
            {
                Movies = _db
                    .Movies
                    .Where(m => m.CategoryId == categoryId)
                    .OrderBy(m => m.Id)
                    .Skip(PAGE_SIZE * pageIndex)
                    .Take(PAGE_SIZE)
                    .ToList(),
                TotalCount = _db.Movies.Where(m => m.CategoryId == categoryId).Count()
            };
        }

        public Movie Post(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
            return movie;
        }


        public Movie Get(int id)
        {
            return _db.Movies.Find(id);
        }

    }
}
