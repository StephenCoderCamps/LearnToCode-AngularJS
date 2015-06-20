using MovieAppServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieAppServer.Views.Movies;

namespace MovieAppServer.Controllers
{
    public class MoviesController : Controller
    {
        const int PAGE_SIZE = 5;

        private ApplicationDbContext _db = new ApplicationDbContext();

        private SelectList GetCategories()
        {
            return new SelectList(_db.Categories.ToList(), "Id", "Name"); 
        }


        // GET: Movies
        public ActionResult Index(int? categoryId = null, int pageIndex = 0)
        {
            Category selectedCategory = null;
            // if categoryId then retrieved selected category
            if (categoryId.HasValue) {
                selectedCategory = _db.Categories.Where(c => c.Id == categoryId).FirstOrDefault(); 
            }
            // if no selected category then get first category
            if (selectedCategory == null) {
                selectedCategory = _db.Categories.OrderBy(c => c.Name).FirstOrDefault(); 
            }

            // load movies
            _db.Entry(selectedCategory)
                .Collection(c => c.Movies)
                .Query()
                .OrderBy(m => m.Id)
                .Skip(PAGE_SIZE * pageIndex)
                .Take(PAGE_SIZE)
                .Load();

            // get total movie count
            var totalMovieCount = _db.Movies.Where(m => m.CategoryId == selectedCategory.Id).Count();

            // build view model
            var vm = new MovieAppServer.Views.Movies.IndexViewModel
            {
                Category = selectedCategory,
                Categories = GetCategories(),
                PageCount = totalMovieCount/PAGE_SIZE,
                CurrentPageIndex = pageIndex
            };

            return View(vm);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            var movie = _db.Movies.Find(id);
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            var vm = new CreateViewModel
            {
                Categories = GetCategories()
            };
            return View(vm);
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid) {
                // add movie to db
                _db.Movies.Add(movie);
                _db.SaveChanges();

                // redirect to success action
                return RedirectToAction("Index");
            }
            // display validation errors
            return View();
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            // get original movie
            var original = _db.Movies.Find(id);
            return View(original);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid) {
                // edit movie in db
                var original = _db.Movies.Find(movie.Id);
                original.Title = movie.Title;
                original.Director = movie.Director;
                _db.SaveChanges();
                
                // redirect to success action
                return RedirectToAction("Index");
            }
            // display validation errors
            return View();
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            // get original movie
            var original = _db.Movies.Find(id);
            return View(original);
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(Movie movie)
        {
            // delete movie from db
            var original = _db.Movies.Find(movie.Id);
            _db.Movies.Remove(original);
            _db.SaveChanges();

            // redirect to success action
            return RedirectToAction("Index");
        }
    }
}
