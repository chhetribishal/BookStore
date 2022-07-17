using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Data;
using Web.BookStore.Models;

namespace Web.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;


       
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                Author = model.Author,
                Category = model.Category,
                Language = model.Language,
                TotalPages = model.TotalPages.HasValue?model.TotalPages.Value:0,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,

            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.ID;

        }
        public async Task<List<BookModel>> GetAllBook()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        ID = book.ID,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookByID(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    ID = book.ID,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;

        }
        //public List<BookModel> SearchBook(string title, string authorName)
        //{
        //    return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        //}


    }
}
