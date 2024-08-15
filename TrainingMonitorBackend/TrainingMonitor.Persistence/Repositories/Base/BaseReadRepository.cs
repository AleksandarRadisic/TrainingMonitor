using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.PersistenceInterfaces.Base;
using TrainingMonitor.Persistence.EfStructures;

namespace TrainingMonitor.Persistence.Repositories.Base
{
    public class BaseReadRepository<TKey, TEntity> : IBaseReadRepository<TKey, TEntity> where TEntity : class, new()
    {
        private readonly AppDbContext _context;

        protected BaseReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual TEntity GetById(TKey id)
        {
            var set = GetSet();
            return set.Find(id);
        }

        protected DbSet<TEntity> GetSet()
        {
            return _context.Set<TEntity>();
        }
    }
}
