using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Exceptions;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.PersistenceInterfaces;
using TrainingMonitor.Domain.Services.Interface;

namespace TrainingMonitor.Domain.Services.Implementation
{
    public class TrainingService : ITrainingService
    {
        public readonly IUserReadRepository _userReadRepository;
        public readonly ITrainingReadRepository _trainingReadRepository;
        public readonly ITrainingWriteRepository _trainingWriteRepository;
        public TrainingService(IUserReadRepository userReadRepository, ITrainingReadRepository trainingReadRepository, ITrainingWriteRepository trainingWriteRepository)
        {
            _userReadRepository = userReadRepository;
            _trainingReadRepository = trainingReadRepository;
            _trainingWriteRepository = trainingWriteRepository;
        }

        public void AddTraining(Training training)
        {
            if (_userReadRepository.FindById(training.UserId) == null)
            {
                throw new NotFoundException("User not found");
            }
            _trainingWriteRepository.Add(training);
        }
    }
}
