using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.DataAccess.Abstract;
using TamFinansCase.DataAccess.Concrete.Repositories;
using TamFinansCase.Entites.Concrete;

namespace TamFinansCase.DataAccess.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
    }
}
