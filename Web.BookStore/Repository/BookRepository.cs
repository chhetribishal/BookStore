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
                new BookModel(){ID=1,Title="MVC",Author="Bishal",Description ="This is Description for MVC",Category="happy",Language="English",TotalPages=345},
                new BookModel(){ID=2,Title="C#",Author="HARI",Description ="This is Description for c#",Category="happy",Language="English",TotalPages=34},
                new BookModel(){ID=3,Title="JAVA",Author="shal",Description ="This is Description for JAVA",Category="happy",Language="English",TotalPages=345},
                new BookModel(){ID=3,Title="JAVA",Author="shal",Description ="This is Description for JAVA",Category="happy",Language="English",TotalPages=345},
                new BookModel(){ID=4,Title="PHP",Author="RAM",Description ="This is Description for PHP",Category="happy",Language="English",TotalPages=345},
                new BookModel(){ID=5,Title="SQL",Author="Shyam",Description ="This is Description for SQL",Category="happy",Language="English",TotalPages=345},
            };
        }
    }
}
