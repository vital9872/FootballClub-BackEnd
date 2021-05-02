using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Football.DAL.Context;
using Football.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Football.DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase
    {
        protected readonly FootballContext Context;
        protected DbSet<TEntity> Entities;

        public Repository(FootballContext context)
        {
            Context = context;
            Entities = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
        }

        public virtual async Task<TEntity> FindByIdAsync(params object[] keys)
        {
            return await Entities.FindAsync(keys);
        }

        public virtual async Task<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            Entities.AddRange(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entity)
        {
            Entities.RemoveRange(entity);
        }

        public virtual void Update(TEntity entity)
        {
            Entities.Update(entity);
        }
    }
}
