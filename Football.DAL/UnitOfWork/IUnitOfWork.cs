using Football.DAL.Entities;
using Football.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Football.DAL
{
    public interface IUnitOfWork<TEntityBase> : IDisposable
        where TEntityBase : class, IEntityBase
    {
        DbContext db { get; }

        IRepository<TEntityBase> GetRepository();

        void SaveChanges();
    }
}
