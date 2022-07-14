using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Models;
using Web.BookStore.Repository;

namespace Web.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public ActionResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBook();
            return View(data);
        }

        [Route("book-details/{id}",Name="bookDetailsRoute")]
        public ActionResult GetBookByID(int id)
        {

            dynamic data = new ExpandoObject();
            data.book = _bookRepository.GetBookByID(id);
            data.Name = "bishu";

            return View(data);

        }

        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ActionResult AddNewBook()
        {

            return View();
        }


        [HttpPost]
        public ActionResult AddNewBook(BookModel book)
        {
           

            return View();
        }
    }
}
