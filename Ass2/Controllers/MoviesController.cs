using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ass2.Data;
using Ass2.Models;
using Ass2.ViewModels;
using PagedList;

namespace Ass2.Controllers
{
    public class MoviesController : Controller
    {
        private Ass2Context db = new Ass2Context();

        // GET: Movies
        public ActionResult Index(string moviecategory, string search,int? page)
        {
            MovieIndexViewModel viewModel = new MovieIndexViewModel();
            var movies = db.Movies.Include(p => p.MovieCategory);

            if (!String.IsNullOrEmpty(search))
            {
                movies = movies.Where(p => p.Name.Contains(search) ||
                p.MovieCategory.Name.Contains(search));
                //  ViewBag.Search = search;
                viewModel.Search = search;
            }

            viewModel.CatsWithCount = from matchingMovies in movies
                                      where matchingMovies.MovieCategoryID != null
                                      group matchingMovies by
                                      matchingMovies.MovieCategory.Name into catGroup
                                      select new CategoryWithCount()
                                      {
                                          MovieCategoryName = catGroup.Key,
                                          MovieCount = catGroup.Count()
                                      };
            if (!String.IsNullOrEmpty(moviecategory))
            {
                movies = movies.Where(p => p.MovieCategory.Name == moviecategory);
                viewModel.MovieCategory = moviecategory;
            }
            movies = movies.OrderBy(p => p.Name);
            const int PageItems = 3;
            int currentPage = (page ?? 1);
            viewModel.Movies = movies.ToPagedList(currentPage, PageItems);
            return View(viewModel);
           
        }
        //获取数据
        public ActionResult YourAction()
        {
            var movies = db.Movies.ToList(); // 查询数据库，获取电影数据
            return View(movies);
        }


        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.MovieCategoryID = new SelectList(db.MovieCategories, "ID", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Score,URL,MovieCategoryID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MovieCategoryID = new SelectList(db.MovieCategories, "ID", "Name", movie.MovieCategoryID);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.MovieCategoryID = new SelectList(db.MovieCategories, "ID", "Name", movie.MovieCategoryID);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Score,URL,MovieCategoryID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MovieCategoryID = new SelectList(db.MovieCategories, "ID", "Name", movie.MovieCategoryID);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
