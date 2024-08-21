using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.PersistenceInterfaces.Base;

namespace TrainingMonitor.Domain.PersistenceInterfaces
{
    public interface ITrainingReadRepository : IBaseReadRepository<Guid, Training>
    {
        public IList<Training> FindUserTrainingsWithinTimeRange(Guid userId, TimeRange timeRange);
    }
}
