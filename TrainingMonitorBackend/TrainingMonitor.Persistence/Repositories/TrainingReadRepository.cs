using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.PersistenceInterfaces;
using TrainingMonitor.Persistence.EfStructures;
using TrainingMonitor.Persistence.Repositories.Base;

namespace TrainingMonitor.Persistence.Repositories
{
    public class TrainingReadRepository : BaseReadRepository<Guid, Training>, ITrainingReadRepository
    {
        public TrainingReadRepository(AppDbContext context) : base(context)
        {
        }

        public IList<Training> FindUserTrainingsWithinTimeRange(Guid userId, TimeRange timeRange)
        {
            var userTrainingsInMonth = GetSet().
                Where(t => t.UserId == userId && 
                           t.TrainingDateTime >= TimeZoneInfo.ConvertTimeToUtc(timeRange.Start) && 
                           t.TrainingDateTime <= TimeZoneInfo.ConvertTimeToUtc(timeRange.End));
            return userTrainingsInMonth.ToList();
        }
    }
}
