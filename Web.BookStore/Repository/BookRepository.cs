using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.BookStore.Models;

namespace Web.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBook()
        {
            return DataSource();
        }

        public BookModel GetBookByID(int id)
        {
            return DataSource().Where(x => x.ID == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ID=1,Title="MVC",Author="Bishal"},
                new BookModel(){ID=2,Title="C#",Author="HARI"},
                new BookModel(){ID=3,Title="JAVA",Author="shal"},
                new BookModel(){ID=4,Title="PHP",Author="RAM"},
                new BookModel(){ID=5,Title="SQL",Author="Shyam"},
            };
        }
    }
}
