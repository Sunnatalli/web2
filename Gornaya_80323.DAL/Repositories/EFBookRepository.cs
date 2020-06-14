using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Gornaya_80323.DAL
{
   public class EFBookRepository : IRepository<Book>

    {
        ApplicationDbContext context;

        private DbSet<Book> books;

        /// <summary>         
        /// Конструктор класса         
        /// </summary>         
        /// <param name="ctx"> имя строки подключения </param>         
        public EFBookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            books = context.Books;
        }
        public void Create(Book t)
        {
            books.Add(t);
            context.SaveChanges();
        }
       
        public void Delete(int id)
        {
            //context.Entry(new Book { BookId = id }).State = EntityState.Deleted;
            //context.SaveChanges();
            Book item = context.Books.Find(id);//почему null?
            if (item != null)
                context.Books.Remove(item);
            context.SaveChanges();
        }        

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return context.Books.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return context.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }

        public Task<Book> GetAsync(int id)
        {
            return context.Books.FindAsync(id);
        }

        public void Update(Book t)
        {
            // если изображение не загружено,
            // то использовать изображение из базы данных
            if(t.Image==null)
            {
                var book = context.Books
                    .AsNoTracking()
                    .Where(d => d.BookId == t.BookId)
                    .FirstOrDefault();
                t.Image = book.Image;
                t.MimeType = book.MimeType;
            }
            context.Entry<Book>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
        
    }
}
