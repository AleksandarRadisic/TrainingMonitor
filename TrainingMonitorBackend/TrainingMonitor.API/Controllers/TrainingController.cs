using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMonitor.API.Dto;
using TrainingMonitor.API.Utilities.Interface;
using TrainingMonitor.Domain.Model;
using TrainingMonitor.Domain.Services.Interface;

namespace TrainingMonitor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly IHttpContextExtractor _contextExtractor;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ITrainingService _trainingService;

        public TrainingController(IHttpContextExtractor contextExtractor, IExceptionHandler exceptionHandler, ITrainingService trainingService)
        {
            _contextExtractor = contextExtractor;
            _exceptionHandler = exceptionHandler;
            _trainingService = trainingService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddTraining(NewTrainingDto dto)
        {
            try
            {
                _trainingService.AddTraining(
                    new Training(dto.TrainingType,
                        dto.TrainingDateTime,
                        dto.Intensity,
                        dto.Fatigue,
                        dto.DurationInMinutes,
                        dto.CaloriesSpent,
                        _contextExtractor.GetUserIdFromContext(HttpContext)));
                return Ok("Training added");
            }
            catch (Exception ex)
            {
                var exResponse = _exceptionHandler.CreateExceptionResponse(ex);
                return StatusCode((int)exResponse.Item1, exResponse.Item2);
            }
        }

        [HttpGet("{year:int}/{month:int}")]
        [Authorize]
        public IActionResult GetTrainingReportForMonth(int year, int month)
        {
            return Ok(_trainingService.GetUserTrainingReportForMonth(year, month,
                _contextExtractor.GetUserIdFromContext(HttpContext)));
        }
    }
}
