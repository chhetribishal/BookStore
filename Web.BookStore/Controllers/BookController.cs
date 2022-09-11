using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<ActionResult> GetAllBooks()
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

        public IActionResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
                //Language = "2"
        };

            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2" ,Disabled = true};
            //var group3 = new SelectListGroup() { Name = "Group3" };

            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Nepali", Value="1"},
                new SelectListItem(){Text = "English",Value="2"} ,
                new SelectListItem(){Text = "French", Value = "3"  },
                new SelectListItem(){Text = "Dutch", Value ="4" },

            };

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
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

            //var group1 = new SelectListGroup() { Name = "Group1" };
            //var group2 = new SelectListGroup() { Name = "Group2", Disabled = true };
            //var group3 = new SelectListGroup() { Name = "Group3" };

            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem(){ Text = "Nepali", Value="1" },
                new SelectListItem(){Text = "English",Value="2"} ,
                new SelectListItem(){Text = "French", Value = "3" },
                new SelectListItem(){Text = "Dutch", Value ="4" },

            };

            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;

            return View();
        }

        private List<Language> GetLanguage() {
            return new List<Language>() {
            new Language() { Id = 1,Text = "Nepali"},
            new Language() { Id =2,Text="English"},
            new Language() { Id = 3, Text = "Dutch" }
        };
            }

    }
}