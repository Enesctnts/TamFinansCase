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
    public class UserManager : IUserService
    {

        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Insert(User user)
        {
            _userDal.Insert(user);
        }
        public void Delete(User user)
        {
            _userDal.Delete(user);
        }
        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public User GetById(int id)
        {
            return _userDal.Get(b => b.UserId == id);
        }

        public List<User> List()
        {
            return _userDal.List();
        }

    }
}
