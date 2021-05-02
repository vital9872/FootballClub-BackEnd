using Football.DAL.Context;
using Football.DAL.Entities;
using Football.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL.UnitOfWork
{
    public sealed class UnitOfWork<TEntity> : IUnitOfWork<TEntity>
        where TEntity : class, IEntityBase
    {
        private FootballContext context;

        public UnitOfWork(FootballContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// Gets DBcontext, is used for disposing
        /// </summary>
        public DbContext db { get => context; }

        /// <summary>
        /// Gets repository for TEntity
        /// </summary>
        /// <returns>instance of repository</returns>
        public IRepository<TEntity> GetRepository()
        {
            return new Repository<TEntity>(context);
        }

        /// <summary>
        /// Saves changes in DB
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }

            disposed = true;
        }
    }
}
