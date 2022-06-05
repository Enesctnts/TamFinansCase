using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TamFinansCase.Business.Concrete;
using TamFinansCase.DataAccess.EntityFramework;
using TamFinansCase.Entites.Concrete;

namespace TamFinansCase.MVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult GetList()
        {
            var bookValues = bookManager.List().Where(x => x.BookStatus == true && x.Category.CategoryStatus==true).ToList();
            return View(bookValues);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            //Tüm Kategorileri DropDownListe getirebilmek için GetCategories metodu yazılmıştır.
            //GetCategories metodu en alttadır.
            ViewBag.vlc = GetCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            try
            {
                ViewBag.vlc = GetCategories();

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Kitap girişleri düzgün olmalıdır");
                    return View(book);
                }

                bookManager.Insert(book);
                System.Threading.Thread.Sleep(1000);//Alert mesajı gözükmesi için 1 sn bekle
                return RedirectToAction("GetList");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Beklenmedik hata oluştu!");
                return View(book);
            }

        }

        public ActionResult DeleteBook(int id)
        {
            var result = bookManager.GetById(id);
            bookManager.Delete(result);
            return RedirectToAction("GetList");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            ViewBag.vlc = GetCategories();
            var result = bookManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBook(Book book)
        {
            try
            {
                ViewBag.vlc = GetCategories();

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Kitap girişleri düzgün olmalıdır");
                    return View(book);
                }

                bookManager.Update(book);
                System.Threading.Thread.Sleep(1000);//Alert mesajı gözükmesi için 1 sn bekle
                return RedirectToAction("GetList");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Beklenmedik hata oluştu!");
                return View(book);
            }

        }

        //Tüm Kategorileri DropDownListe getirebilmek için GetCategories metodu yazılmıştır.
        public List<SelectListItem> GetCategories()
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.List().Where(x=>x.CategoryStatus==true)
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            return valuecategory;
        }
    }
}