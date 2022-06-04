using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TamFinansCase.Business.Concrete;
using TamFinansCase.DataAccess.EntityFramework;
using TamFinansCase.Entites.Concrete;
using TamFinansCase.MVC.Models;

namespace TamFinansCase.MVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        BookManager bookManager = new BookManager(new EfBookDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult GetList()
        {
            var bookValues = bookManager.List().Where(x => x.BookStatus == true).ToList();
            return View(bookValues);
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()

                                                  }).ToList();
            ViewBag.vlc = valuecategory;

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBook(Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Kitap girişleri düzgün olmalıdır");
                    return View(book);
                }

                if (book.CategoryId <= 0)
                {
                    ModelState.AddModelError("", "Ürüne ait kategori seçilmelidir");
                    return View(book);
                }

                bookManager.Insert(book);
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

            List<SelectListItem> valuecategory = (from x in categoryManager.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var result = bookManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBook(Book book)
        {
            try
            {
                List<SelectListItem> valuecategory = (from x in categoryManager.List()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.CategoryName,
                                                          Value = x.CategoryId.ToString()
                                                      }).ToList();
                ViewBag.vlc = valuecategory;

                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Kitap girişleri düzgün olmalıdır");
                    return View(book);
                }

                if (book.CategoryId <= 0)
                {
                    ModelState.AddModelError("", "Ürüne ait kategori seçilmelidir");
                    return View(book);
                }

                bookManager.Update(book);
                return RedirectToAction("GetList");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Beklenmedik hata oluştu!");
                return View(book);
            }


        }


    }
}