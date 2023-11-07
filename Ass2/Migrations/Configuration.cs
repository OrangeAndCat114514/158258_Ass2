namespace Ass2.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Ass2.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Ass2.Data.Ass2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Ass2.Data.Ass2Context";
        }

        protected override void Seed(Ass2.Data.Ass2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var movieCategories = new List<MovieCategory>
            {
                new MovieCategory{Name = "Hot"},
                new MovieCategory{Name = "Latest"},
                new MovieCategory{Name = "Great"},
                new MovieCategory{Name = "Europe And America"},
                new MovieCategory{Name = "Korean"},
               
            };
            movieCategories.ForEach(c => context.MovieCategories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var movies = new List<Movie>()
            {
                new Movie {Name = "Anatomy of a fall",Score = 8.4,URL = "~/Content/Images/hot/AnatomyOfAFall.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "Saw X",Score = 7.5,URL = "~/Content/Images/hot/SawX.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "Long Live Love",Score = 7.6,URL = "~/Content/Images/hot/LongLiveLove.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "The Killer",Score = 6.7,URL = "~/Content/Images/hot/TheKiller.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "Old Dads",Score = 6.4,URL = "~/Content/Images/hot/OldDads.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},

                new Movie {Name = "Passed Through the storm",Score = 6.6,URL = "~/Content/Images/hot/Passed Through the storm.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "Sound Of Freedom",Score = 7.8,URL = "~/Content/Images/hot/Sound Of Freedom.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "Revenge",Score = 6.9,URL = "~/Content/Images/hot/Revenge.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "Nowhere",Score = 7.0,URL = "~/Content/Images/hot/Nowhere.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
                new Movie {Name = "Learn From Dad",Score = 6.1,URL = "~/Content/Images/hot/Learn From Dad.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Hot").ID},
               
                new Movie {Name = "Shyloch's children",Score = 6.8,URL = "~/Content/Images/latest/Shyloch's children.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Latest").ID},
                new Movie {Name = "Beautiful diaster",Score = 5.5,URL = "~/Content/Images/latest/Beautiful diaster.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Latest").ID},
                new Movie {Name = "Sleep",Score = 5.8,URL = "~/Content/Images/latest/Sleep.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Latest").ID},
                new Movie {Name = "The Burial",Score =7.0 ,URL = "~/Content/Images/latest/The Burial.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Latest").ID},
                new Movie {Name = "Assault",Score = 6.9,URL = "~/Content/Images/latest/Assault.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Latest").ID},

                new Movie {Name = "Oh My God",Score = 7.3,URL = "~/Content/Images/latest/Oh My God.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Great").ID},
                new Movie {Name = "Inference",Score = 6.8,URL = "~/Content/Images/latest/Inference.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Great").ID},
                new Movie {Name = "She is so sweet",Score = 5.4,URL = "~/Content/Images/latest/She is so sweet.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Great").ID},
                new Movie {Name = "Roman Prince",Score = 7.2,URL = "~/Content/Images/latest/Roman Prince.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Great").ID},
                new Movie {Name = "Harold Fry",Score = 7.4,URL = "~/Content/Images/latest/Harold Fry.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Great").ID},

                new Movie {Name = "Barbie",Score = 8.1,URL = "~/Content/Images/EAA/Barbie.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Europe And America").ID},
                new Movie {Name = "Forrest Gump",Score = 9.5,URL = "~/Content/Images/EAA/Forrest Gump‎.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Europe And America").ID},
                new Movie {Name = "Leon",Score = 9.4,URL = "~/Content/Images/EAA/Leon.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Europe And America").ID},
                new Movie {Name = "Shawshank",Score = 9.7,URL = "~/Content/Images/EAA/Shawshank.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Europe And America").ID},
                new Movie {Name = "The Truman Show",Score = 9.4,URL = "~/Content/Images/EAA/The Truman Show‎.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Europe And America").ID},

                new Movie {Name = "Memory of Murder",Score = 8.9,URL = "~/Content/Images/Korean/Memory of Murder.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Korean").ID},
                new Movie {Name = "Parasite",Score = 8.8,URL = "~/Content/Images/Korean/Parasite.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Korean").ID},
                new Movie {Name = "도가니‎",Score = 9.4,URL = "~/Content/Images/Korean/도가니‎.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Korean").ID},
                new Movie {Name = "부산행‎",Score = 8.6,URL = "~/Content/Images/Korean/부산행‎.jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Korean").ID},
                new Movie {Name = "소원‎ ",Score = 9.3,URL = "~/Content/Images/Korean/소원‎ .jpg",MovieCategoryID = movieCategories.Single(c => c.Name == "Korean").ID},




            };
            movies.ForEach(c => context.Movies.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
        }
    }
}
