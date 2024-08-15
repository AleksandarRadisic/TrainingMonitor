using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace TrainingMonitor.API.Utilities.Interface
{
    public interface IExceptionHandler
    {
        public Tuple<HttpStatusCode, string> CreateExceptionResponse(Exception exception);
    }
}
