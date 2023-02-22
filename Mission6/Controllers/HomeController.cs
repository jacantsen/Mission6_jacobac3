using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        
        private MovieFormContext MovieContext { get; set; }
        public HomeController( MovieFormContext someName)
        {
         
            MovieContext = someName;
        }
        //show the home page
        public IActionResult Index()
        {
            return View();
        }
        // show the podcast page
        [HttpGet]
        public IActionResult MyPodcasts()
        {
            return View();
        }
        // show the movie form
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = MovieContext.categories.ToList();
            return View();
        }
        //post the movie form data
        [HttpPost]
        public IActionResult MovieForm(MovieFormResponse movie)
            // save the form data into the database
        {
            if (ModelState.IsValid)
            {

               
                MovieContext.Add(movie);
                MovieContext.SaveChanges();
                // show the list of movies after they add one
                var read_list = MovieContext.responses
                .Include(x => x.Category).ToList();

                return View("Movie_list", read_list);
            }
            else
            {
                ViewBag.Categories = MovieContext.categories.ToList();
                return View();
            }
        }
        // get list from database and send it to the list page
        [HttpGet]
        public IActionResult Movie_list()
        {
            var read_list = MovieContext.responses
                .Include(x => x.Category).ToList();
            return View(read_list);
        }
        // get the info for the edited field and send to movie form
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = MovieContext.categories.ToList();

            var movie_data = MovieContext.responses.Single(x=>x.ApplicationID == applicationid);
            
            return View("MovieForm", movie_data);
        }
        // update the database
        [HttpPost]
        public IActionResult Edit(MovieFormResponse blah)
        {
            {

                MovieContext.Update(blah);
                MovieContext.SaveChanges();
                return RedirectToAction("Movie_list");
            }

        }
        // delete the chosen field from the database
        [HttpGet]
        public IActionResult Delete( int applicationid)
        {
            var movie = MovieContext.responses.Single(x => x.ApplicationID == applicationid);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieFormResponse movie)
        {
            MovieContext.responses.Remove(movie);
            MovieContext.SaveChanges();
            return RedirectToAction("Movie_list");
        }

    }
}
