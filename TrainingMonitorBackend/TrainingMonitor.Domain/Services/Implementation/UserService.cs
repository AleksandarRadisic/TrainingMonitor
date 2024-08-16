using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingMonitor.Domain.Exceptions;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.PersistenceInterfaces;
using TrainingMonitor.Domain.Services.Interface;
using TrainingMonitor.Domain.Utilities.Implementation;
using TrainingMonitor.Domain.Utilities.Interface;

namespace TrainingMonitor.Domain.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IJwtUtility _jwtUtility;
        private readonly IEncryptionUtility _encryptionUtility;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserWriteRepository _userWriteRepository;
        public UserService(IJwtUtility jwtUtility, IUserReadRepository userReadRepository, IUserWriteRepository userWriteRepository, IEncryptionUtility encryptionUtility)
        {
            _jwtUtility = jwtUtility;
            _userReadRepository = userReadRepository;
            _userWriteRepository = userWriteRepository;
            _encryptionUtility = encryptionUtility;
        }

        public void Register(User user)
        {
            if (_userReadRepository.FindByEmail(user.Email) != null)
            {
                throw new AlreadyExistsException("Email already used");
            }
            user.Password = _encryptionUtility.Encrypt(user.Password);
            _userWriteRepository.Add(user);
        }

        public string Login(string email, string password)
        {
            var user = _userReadRepository.FindByEmailAndPassword(email, _encryptionUtility.Encrypt(password));
            if (user == null) throw new NotFoundException("Wrong email and/or password");

            return _jwtUtility.GenerateToken(user);
        }

        public User GetUser(Guid id)
        {
            var user = _userReadRepository.FindByIdEager(id);
            user.Trainings = user.Trainings.OrderBy(t => t.TrainingDateTime).ToList();
            return _userReadRepository.FindByIdEager(id);
        }
    }
}
