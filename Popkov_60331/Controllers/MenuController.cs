using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gornaya_80323.Models;
using Gornaya_80323.DAL;


namespace Gornaya_80323.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;
        IRepository<Book> repository;

        public MenuController(IRepository<Book> repo)
        {
            items = new List<MenuItem>
            {
                new MenuItem {Name="Домой", Controller="Home",Action="Index",Active="string.Empty"},
                new MenuItem {Name="Каталог", Controller="Book",Action="List",Active="string.Empty"},
                new MenuItem {Name="Администрирование", Controller="Admin",Action="Index",Active="string.Empty"}
            };

            repository = repo;
        }
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            try
            {
                items.First(m => m.Controller == c).Active = "active";
                return PartialView(items);
            }
            catch (Exception)
            {
                return PartialView(items);
            }
        }

        public PartialViewResult UserInfo()
        {
            return PartialView();
        }
        public PartialViewResult Side()
        {
            var types = repository.GetAll().
                                    Select(d => d.BookType).
                                    Distinct();
            return PartialView(types);
        }
        public PartialViewResult Map()
        {
            return PartialView(items);
        }
    }
}