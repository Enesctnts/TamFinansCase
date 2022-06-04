using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TamFinansCase.DataAccess.Abstract;
using TamFinansCase.Entites.Abstract;

namespace TamFinansCase.DataAccess.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        Context context = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T t)
        {
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); 
        }

        public void Insert(T t)
        {
            var addedEntity = context.Entry(t);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T t)
        {
            var editedEntity = context.Entry(t);
            editedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
