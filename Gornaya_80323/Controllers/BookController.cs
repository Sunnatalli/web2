using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gornaya_80323.DAL;
using Gornaya_80323.Models;
using System.Threading.Tasks;


namespace Gornaya_80323.Controllers
{
    public class BookController : Controller
    {
        //инициализация списка объектов
        //List<Book> books = new List<Book>
        //{
        //new Book {BookId = 1, BookTitle = "Pride and Prejudice", BookAuthor = "Jane Austen", Description = "English Classics",
        //        BookType = "Novel" },
        //    new Book {BookId = 2, BookTitle = "Jane Eyre", BookAuthor = "Charlotte Brontë",
        //        Description = "English Classics", BookType = "Novel"},
        //    new Book {BookId = 3, BookTitle = "Romeo and Juliet", BookAuthor = " William Shakespeare",
        //        Description = "English Classics", BookType = "Novel" },
        //    new Book {BookId = 4, BookTitle = "Frankenstein", BookAuthor = " Mary Wollstonecraft Shelley",  Description = "English Literature",
        //        BookType = "Story"},
        //    new Book {BookId = 5, BookTitle = "A Hero of Our Time ", BookAuthor = " Mikhail Lermontov", Description = "Russian Classics",
        //        BookType = "Novel"
        //    } };
        IRepository<Book> repository;
        int pageSize = 3;

        public BookController(IRepository<Book> repo)
        {
            repository = repo;
        }
        // GET: Book
        public ActionResult List(string type, int page = 1)
        {
            //return View(books);
            var lst = repository.GetAll()
                .Where (d=>type==null || d.BookType.Equals(type))
                .OrderBy(d => d.BookPrice);
            var model = PageListViewModel<Book>.CreatePage(lst, page, pageSize);
            if(Request.IsAjaxRequest())
            {
                return PartialView("ListPartial",model);
            }
            return View(model);
        }

        public async Task<FileResult>  GetImage(int id)
        {
            var book = await repository.GetAsync(id);
            if (book != null)
            {
                return new FileContentResult(book.Image, book.MimeType);
            }
            else return null;
        }
       
    }
}