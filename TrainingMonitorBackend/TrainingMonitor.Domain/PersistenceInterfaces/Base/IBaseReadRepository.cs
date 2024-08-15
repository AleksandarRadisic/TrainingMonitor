using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitor.Domain.PersistenceInterfaces.Base
{
    public interface IBaseReadRepository<TKey, TEntity> where TEntity : class
    {
        TEntity GetById(TKey id);
    }
}
