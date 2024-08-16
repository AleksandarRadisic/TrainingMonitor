using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMonitor.API.Dto;
using TrainingMonitor.API.Utilities.Interface;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.PersistenceInterfaces;
using TrainingMonitor.Domain.Services.Interface;

namespace TrainingMonitor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IHttpContextExtractor _contextExtractor;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IUserService _userService;

        public UsersController(IHttpContextExtractor contextExtractor, IExceptionHandler exceptionHandler, IUserService userService)
        {
            _exceptionHandler = exceptionHandler;
            _userService = userService;
            _contextExtractor = contextExtractor;
        }

        [HttpPost("register")]
        public IActionResult RegisterUser(RegistrationDto dto)
        {
            var user = new User
            {
                Email = dto.Email,
                Gender = dto.Gender,
                Name = dto.Name,
                Surname = dto.Surname,
                Password = dto.Password
            };
            try
            {
                _userService.Register(user);
            }
            catch (Exception ex)
            {
                var exResponse = _exceptionHandler.CreateExceptionResponse(ex);
                return StatusCode((int)exResponse.Item1, exResponse.Item2);
            }
            return Ok("Registration finished successfully");
        }

        [HttpPost("login")]
        public IActionResult LogIn(LogInDto dto)
        {
            try
            {
                return Ok(_userService.Login(dto.Email, dto.Password));
            }
            catch (Exception ex)
            {
                var exResponse = _exceptionHandler.CreateExceptionResponse(ex);
                return StatusCode((int)exResponse.Item1, exResponse.Item2);
            }
        }

        [HttpGet("logged")]
        [Authorize]
        public IActionResult GetLoggedUser()
        {
            try
            {
                var user = _userService.GetUser(_contextExtractor.GetUserIdFromContext(HttpContext));
                if (user == null) return NotFound("User not found");
                return Ok(user);
            }
            catch (Exception ex)
            {
                var exResponse = _exceptionHandler.CreateExceptionResponse(ex);
                return StatusCode((int)exResponse.Item1, exResponse.Item2);
            }

        }
    }
}
