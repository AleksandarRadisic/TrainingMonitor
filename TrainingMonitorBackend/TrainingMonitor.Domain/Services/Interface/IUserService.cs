using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Model;

namespace TrainingMonitor.Domain.Services.Interface
{
    public interface IUserService
    {
        public void Register(User user);
        public string Login(string email, string password);
    }
}
