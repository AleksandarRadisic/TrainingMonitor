using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Model;

namespace TrainingMonitor.Domain.Utilities.Interface
{
    public interface IJwtUtility
    {
        public string GenerateToken(User user);
    }
}
