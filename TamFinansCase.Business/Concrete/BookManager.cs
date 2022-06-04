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
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void Insert(Book book)
        {
            _bookDal.Insert(book);
        }
        public void Delete(Book book)
        {
            book.BookStatus = false;
            _bookDal.Delete(book);

        }
        public void Update(Book book)
        {
            _bookDal.Update(book);
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(b => b.BookId == id);
        }

        public List<Book> List()
        {
            return _bookDal.List();
        }


    }
}
