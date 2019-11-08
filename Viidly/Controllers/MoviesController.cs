using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viidly.Models;
using Viidly.ViewModels;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Viidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        //constructor
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageMovie))
               return View("List");
            return View("ReadOnlylist");
        }
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var Genre = _context.Genres.ToList();
 
            var viewModel = new MovieFormViewModel
            {
                
                Genres= Genre
                
            };
            return View("MovieForm", viewModel);
        }
        [Authorize(Roles = RoleName.CanManageMovie)]

        public ActionResult Edit(int id)
            {
                var movie = _context.movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                    return HttpNotFound();

                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

              

            return View("MovieForm", viewModel);
        }
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovie)]

        public ActionResult Save(Movie moviee)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(moviee)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (moviee.Id == 0)
            {
                moviee.DateAdded = DateTime.Now;
                _context.movies.Add(moviee);
            }

            else
            {
                var MovieInDb = _context.movies.Single(c => c.Id == moviee.Id);


                MovieInDb.Name = moviee.Name;
                MovieInDb.ReleaseDate = moviee.ReleaseDate;
                MovieInDb.GenreId = moviee.GenreId;
                MovieInDb.NumInStock = moviee.NumInStock;
              

            }

                _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

         public ActionResult Details(int id)
        {
            var movie = _context.movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "shrek!" };
            var Customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer { Name = "Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = Customers

            };

            return View(viewModel);
            // return RedirectToAction("Index", "Home", new { page = 1 , sortBy = "name" });
        }
        /* public ActionResult Edit(int id )
         {
             return Content("id=" + id);
         }
         //movies
         public ActionResult Index(int? PageIndex, string SortBy)
         {
               if(!PageIndex.HasValue)
                 PageIndex = 1;
             if (string.IsNullOrWhiteSpace(SortBy))
                 SortBy = "Name";
             return Content(string.Format("PageIndex={0}&SortBy={1}",PageIndex,SortBy));
         }
         [Route("movies/released/{year}/{month}")]
         public ActionResult ByReleaseDate(int year, int month)
         {
             return Content(year +"/" + month);
         }*/
    }
}