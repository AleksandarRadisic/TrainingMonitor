using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.PersistenceInterfaces.Base;

namespace TrainingMonitor.Domain.PersistenceInterfaces
{
    public interface IUserReadRepository : IBaseReadRepository<Guid, User>
    {
        public User FindByEmailAndPassword(string email, string password);
        public User FindByEmail(string email);
    }
}
