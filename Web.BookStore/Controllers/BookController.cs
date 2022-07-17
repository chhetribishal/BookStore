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

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ActionResult>GetAllBooks()
        {
            var data = await _bookRepository.GetAllBook();
            return View(data);
        }

        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ActionResult> GetBookByID(int id)
        {

            dynamic data = new ExpandoObject();
            data.book = await _bookRepository.GetBookByID(id);
            data.Name = "bishu";

            return View(data);

        }

        //public List<BookModel> SearchBooks(string bookName, string authorName)
        //{
        //    return _bookRepository.SearchBook(bookName, authorName);
        //}

        public  IActionResult AddNewBook(bool isSuccess=false,int bookId =0)
        {
            ViewBag.IsSuccess = isSuccess ;
            ViewBag.BookId = bookId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel book)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(book);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, bookId = id });
                }

            }
            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;
          
            return View();
        }
    }
}
