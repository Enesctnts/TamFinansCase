using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.Business.Abstract;
using TamFinansCase.DataAccess.Abstract;
using TamFinansCase.Entites.Concrete;

namespace TamFinansCase.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Insert(Category category)
        {
            _categoryDal.Insert(category);
        }
        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }
        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
            return _categoryDal.Get(b => b.CategoryId == id);
        }

        public List<Category> List()
        {
            return _categoryDal.List();
        }

       
    }
}
