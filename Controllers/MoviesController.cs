using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tema1.Data;
using Tema1.Models;

namespace Tema1.Controllers
{
    public class MoviesController : Controller
    {
        static private List<Movie> movies = new List<Movie>(); 

        private readonly Tema1Context _context;

        public IActionResult Index()
        {
            return View(movies);
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("id,name,genre,year,imdbRating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.id = Guid.NewGuid();
                movies.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("id,name,genre,year,imdbRating")] Movie movie)
        {
            if (id != movie.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var currentMovie = movies.Find(m => m.id == id);
                currentMovie.name = movie.name;
                currentMovie.genre = movie.genre;
                currentMovie.imdbRating = movie.imdbRating;
                currentMovie.year = movie.year;

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = movies.Find(m => m.id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var movie = movies.Find(m => m.id == id);
            movies.Remove(movie);
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(Guid id)
        {
            return movies.Any(e => e.id == id);
        }
    }
}
