using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TamFinansCase.Business.Concrete;
using TamFinansCase.DataAccess.EntityFramework;
using TamFinansCase.Entites.Concrete;

namespace TamFinansCase.MVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult GetCategoryList()
        {
            var categoryValues = categoryManager.List().Where(x => x.CategoryStatus == true).ToList();
            return View(categoryValues);
        }

        [HttpGet] 
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Kategori girişi düzgün olmalıdır!");
                    return View(category);
                }

                categoryManager.Insert(category);
                System.Threading.Thread.Sleep(1000);//Alert mesajı gözükmesi için 1 sn bekle
                return RedirectToAction("GetCategoryList");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Beklenmedik hata oluştu!");
                return View(category);
            }

        }
         
        public ActionResult DeleteCategory(int id)
        {
            var result = categoryManager.GetById(id);
            categoryManager.Delete(result);
            return RedirectToAction("GetCategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var result = categoryManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Kategori girişi düzgün olmalıdır!");
                    return View(category);
                }

                categoryManager.Update(category);
                System.Threading.Thread.Sleep(1000);//Alert mesajı gözükmesi için 1 sn bekle
                return RedirectToAction("GetCategoryList");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Beklenmedik hata oluştu!");
                return View(category);
            }
        }
    }
}
