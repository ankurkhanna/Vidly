using MyMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVCApplication.ViewModel;

namespace MyMVCApplication.Controllers
{
    public class MoviesController : Controller
    {
        // GET: MOvies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "HangOut" };
            //var viewResult = new ViewResult();
            //_ = viewResult.ViewData.Model;

            //ViewData["RandomMovie"] = movie;
            //ViewBag.Movie = movie;

            var customers = new List<Customer> {
                new Customer{Name="Customer 1" },
                new Customer{ Name="Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);
            //return Content("Hello world");
            //return new ViewResult();
            //return new HttpNotFoundResult();
            //return RedirectToAction("Index","Home", new { page=1, sortBy="name"});
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id = " + id);
        }
        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(string.Format("pageindex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}