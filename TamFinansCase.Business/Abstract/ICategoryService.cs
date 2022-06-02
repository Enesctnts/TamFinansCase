using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.Entites.Concrete;

namespace TamFinansCase.Business.Abstract
{
    public interface ICategoryService
    {
        void Insert(Category category);
        void Update(Category category);
        void Delete(Category category);
        List<Category> List();
        Category GetById(int id);
    }
}
