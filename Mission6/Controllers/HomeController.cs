using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private MovieFormContext MovieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieFormContext someName)
        {
            _logger = logger;
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

                return View();
            }
            else
            {
                return View();
            }
        }

            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
