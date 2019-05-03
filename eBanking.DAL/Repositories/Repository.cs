using eBanking.Model.DBModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;


namespace eBanking.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbset;

        public Repository(eBankingContext ctx)
        {
            context = ctx;
            dbset = ctx.Set<T>();
        }

        public IEnumerable<T> List(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> ret;
            ret = dbset.AsNoTracking();

            return filter == null ? ret : ret.Where(filter);
        }

        public int Add(T entity, bool saveChanges = true)
        {
            var e = dbset.Add(entity);

            if (saveChanges)
                SaveChanges();

            return e.Id;
        }

        public IEnumerable<T> AddRange(ICollection<T> entities)
        {
            var e = dbset.AddRange(entities);
            SaveChanges();

            return e;
        }

        public T FindById(int Id)
        {
            return dbset.AsNoTracking().FirstOrDefault(t => t.Id == Id);
        }

        public void Update(T entity, bool saveChanges = true)
        {
            dbset.AddOrUpdate(entity);
            //var oldEntity = FindById(entity.Id);

            //if (oldEntity != null)
            //{
            //    context.Entry(oldEntity).CurrentValues.SetValues(entity);
            //}
            if (saveChanges)
            {
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
