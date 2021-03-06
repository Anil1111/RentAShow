﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAShow.Models;
using RentAShow.ViewModels;

namespace RentAShow.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Random()
        {
            Movie movie = new Movie() { ID = 1, Name = "Shrek!" };

            var customers = new List<Customer>{
                new Customer{Id=1, Name ="Alex"},
                new Customer{Id=2, Name="Matt"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
     

        [Route("Movies/ByReleasedDate/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]

        public ContentResult MovieByRealsedDate(int month, int year)
        {
            return Content(string.Format("Month {0} , Year{1}", month, year));
        }

        public ViewResult MovieList()
        {

            var movieList = GetAllMovies();

            return View(movieList);
        }

        public ViewResult Details(int id)
        {
            var movie = GetAllMovies().Where(x => x.ID == id).FirstOrDefault();

            return View(movie);
        }

        private IEnumerable<Movie> GetAllMovies()
        {
            try
            {
                return new List<Movie>{
                    new Movie{ID=1,Name="Shrek!"},
                    new Movie{ID=2,Name="Wall E"}
                };
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error while getting all movies: " +ex.Message);
            }
        }

    }
}