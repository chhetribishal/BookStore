using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            return View();
        }

        public BookModel GetBookByID(int id)
        {
            return _bookRepository.GetBookByID(id);

        }

        public List<BookModel> SearchBooks(string bookName,string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
    }
}
