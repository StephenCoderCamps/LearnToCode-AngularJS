namespace MovieAppClient.Migrations
{
    using MovieAppClient.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieAppClient.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // clear out old data
            var oldMovies = context.Movies.ToList();
            oldMovies.ForEach(m => context.Movies.Remove(m));
            context.SaveChanges();

            var oldCategories = context.Categories.ToList();
            oldCategories.ForEach(c => context.Categories.Remove(c));
            context.SaveChanges();


            // add new data
            var categories = new List<Category> {
                new Category {Name="Action"},
                new Category {Name="Science Fiction"},
                new Category {Name="Drama"}
            };

            // add each category and 100 movies for each category
            foreach (var category in categories) {
                context.Categories.Add(category);
                context.SaveChanges();
                for (var i = 0; i < 100; i++) {
                    var movie = new Movie
                    {
                        Title = category.Name + " movie " + i,
                        Director = "Director" + i
                    };
                    category.Movies.Add(movie);
                    context.SaveChanges();
                }
            }

        }
    }
}
