using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.PersistenceInterfaces;
using TrainingMonitor.Persistence.EfStructures;
using TrainingMonitor.Persistence.Repositories.Base;

namespace TrainingMonitor.Persistence.Repositories
{
    public class UserReadRepository : BaseReadRepository<Guid, User>, IUserReadRepository
    {
        public UserReadRepository(AppDbContext context) : base(context)
        {
        }

        public User FindByEmailAndPassword(string email, string password)
        {
            return GetSet().FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User FindByEmail(string email)
        {
            return GetSet().FirstOrDefault(u => u.Email == email);
        }

        public User FindByIdEager(Guid id)
        {
            return GetSet().Include(u => u.Trainings).FirstOrDefault(u => u.Id == id);
        }
    }
}
