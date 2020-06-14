using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gornaya_80323.DAL;

namespace Gornaya_80323.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        IRepository<Book> repository;

        public AdminController(IRepository<Book> repo)
        {
            repository = repo;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Book());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Book book, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, (int)count);
                    book.MimeType = imageUpload.ContentType;
                }
                try
                {
                    repository.Create(book);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else return View(book);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    book.Image = new byte[count];
                    imageUpload.InputStream.Read(book.Image, 0, (int)count);
                    book.MimeType = imageUpload.ContentType;
                }

                try
                {
                    // TODO: Add update logic here
                    repository.Update(book);
                    TempData["message"] = string.Format("Объект успешно изменен.");
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(book);
                }
            }
            else return View(book);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete logic here
            repository.Delete(id);
            TempData["message"] = string.Format("Объект успешно удален.");
            return RedirectToAction("Index");

        }
    }
}


