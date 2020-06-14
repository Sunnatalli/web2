using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gornaya_80323.DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Book> Books { get; set; }

        public void Populate()
        {
            if (!Roles.Any())
            {
                // Создаем менеджеры ролей и пользователей
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));
                // Создаем роли "admin" и "user"
                roleManager.Create(new IdentityRole("admin"));
                roleManager.Create(new IdentityRole("user"));
                // Создаем пользователя
                var userAdmin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru",
                    NickName = "Natallia"
                };
                userManager.CreateAsync(userAdmin, "123456").Wait();
                // Добавляем созданного пользователя в администраторы
                userManager.AddToRole(userAdmin.Id, "admin");
            }

            if (!Books.Any())
            {
                List<Book> books = new List<Book>
            {
                new Book { BookTitle = "Pride and Prejudice", BookAuthor = "Jane Austen", Description = "English Classics",
                BookType = "Novel",BookPrice=11 },
            new Book { BookTitle = "Jane Eyre", BookAuthor = "Charlotte Brontë",
                Description = "English Classics", BookType = "Novel",BookPrice=15},
            new Book { BookTitle = "Romeo and Juliet", BookAuthor = " William Shakespeare",
                Description = "English Classics", BookType = "Novel",BookPrice=10 },
            new Book { BookTitle = "Frankenstein", BookAuthor = " Mary Wollstonecraft Shelley",  Description = "English Literature",
                BookType = "Story",BookPrice=13},
            new Book { BookTitle = "A Hero of Our Time ", BookAuthor = " Mikhail Lermontov", Description = "Russian Classics",
                BookType = "Novel",BookPrice=18
            }};
                Books.AddRange(books);
                SaveChanges();
            }
        }
    }

}
