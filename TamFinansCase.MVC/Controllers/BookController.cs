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

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }


        //[Authorize]
        public ActionResult GetList()
        {
            var bookValues = bookManager.List();
            var values = bookValues.Where(x => x.IsDeleted == false).ToList();
            return View(values);
        }

        //[Authorize]
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

        //[Authorize]
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("", "Kitap girişleri düzgün olmalıdır");
                return View(book);
            }

            bookManager.Insert(book);
            return RedirectToAction("GetList");

          
        }

        //[Authorize]
        public ActionResult DeleteBook(int id)
        {
            var result = bookManager.GetById(id);
            bookManager.Delete(result);
            return RedirectToAction("GetList");
        }

        //[Authorize]
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

        //[Authorize]
        [HttpPost]
        public ActionResult UpdateBook(Book book)
        {

            if (!ModelState.IsValid)
            {
                bookManager.Update(book);
                return RedirectToAction("GetList");

               
            }
            else
            {
                ModelState.AddModelError("", "Kitap girişleri düzgün olmalıdır");
            }

            return View();
           
            


        }
    }
}