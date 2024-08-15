using Microsoft.AspNetCore.Mvc;
using System.Net;
using TrainingMonitor.API.Utilities.Interface;
using TrainingMonitor.Domain.Exceptions;

namespace TrainingMonitor.API.Utilities.Implementation
{
    public class ExceptionHandler : IExceptionHandler
    {
        public Tuple<HttpStatusCode, string> CreateExceptionResponse(Exception exception)
        {
            switch (exception)
            {
                case AlreadyExistsException: return new Tuple<HttpStatusCode, string>(HttpStatusCode.BadRequest, exception.Message);
                case NotFoundException: return new Tuple<HttpStatusCode, string>(HttpStatusCode.NotFound, exception.Message);
                case ArgumentException: return new Tuple<HttpStatusCode, string> (HttpStatusCode.BadRequest, exception.Message);
                default:
                    return new Tuple<HttpStatusCode, string>(HttpStatusCode.InternalServerError,
                        "Oops, something went wrong, try again!");
            }
        }
    }
}
