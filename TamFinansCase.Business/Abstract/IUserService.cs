using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.Entites.Concrete;

namespace TamFinansCase.Business.Abstract
{
    public interface IUserService
    {
        void Insert(User user);
        void Update(User user);
        void Delete(User user);
        List<User> List();
        User GetById(int id);
    }
}
