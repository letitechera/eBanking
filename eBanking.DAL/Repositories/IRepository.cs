using eBanking.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace eBanking.DAL.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> List(Expression<Func<T, bool>> filter = null);
        int Add(T entity, bool saveChanges = true);
        IEnumerable<T> AddRange(ICollection<T> entities);
        void Update(T entity, bool saveChanges = true);
        T FindById(int Id);
        void SaveChanges();
    }
}
