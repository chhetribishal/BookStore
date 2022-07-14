using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Web.BookStore.Models;

namespace Web.BookStore.Controllers
{
    public class HomeController:Controller
    {
        [ViewData]
        public string Title { get; set; }

        [ViewData]

        public BookModel Book { get; set; }
        public ViewResult Index()
        {
            dynamic data = new ExpandoObject();
           
            Title = "Home Page From Controller";

            Book = new BookModel() { ID = 1, Author = "hariradheshayam" };
           
            return View();
           
        }

        public ViewResult AboutUs()
        {
            Title = "AboutUs Page From Controller";
            return View();
        }
        public ViewResult ContactUs()
        {
            Title = "ContacUs From Controller";
            return View();
        }
    }
}
