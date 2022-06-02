using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.Entites.Concrete;

namespace TamFinansCase.Business.Abstract
{
    public interface IBookService
    {
        void Insert(Book book);
        void Update(Book book);
        void Delete(Book book);
        List<Book> List();
        Book GetById(int id); 
    }
}
