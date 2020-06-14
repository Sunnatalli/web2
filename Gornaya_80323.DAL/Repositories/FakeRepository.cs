using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gornaya_80323.DAL
{
    public class FakeRepository : IRepository<Book>
    {
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>
            {
                new Book {BookId = 1, BookTitle = "Pride and Prejudice", BookAuthor = "Jane Austen", Description = "English Classics",
                BookType = "Novel",BookPrice=11 },
            new Book {BookId = 2, BookTitle = "Jane Eyre", BookAuthor = "Charlotte Brontë",
                Description = "English Classics", BookType = "Novel",BookPrice=15},
            new Book {BookId = 3, BookTitle = "Romeo and Juliet", BookAuthor = " William Shakespeare",
                Description = "English Classics", BookType = "Novel",BookPrice=10 },
            new Book {BookId = 4, BookTitle = "Frankenstein", BookAuthor = " Mary Wollstonecraft Shelley",  Description = "English Literature",
                BookType = "Story",BookPrice=13},
            new Book {BookId = 5, BookTitle = "A Hero of Our Time ", BookAuthor = " Mikhail Lermontov", Description = "Russian Classics",
                BookType = "Novel",BookPrice=18
            } };
        }
        public Book Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            throw new NotImplementedException();
        }
        public void Create(Book t)
        {
            throw new NotImplementedException();
        }
        public void Update(Book t)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}
