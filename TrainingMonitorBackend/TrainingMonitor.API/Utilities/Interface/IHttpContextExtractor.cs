namespace TrainingMonitor.API.Utilities.Interface
{
    public interface IHttpContextExtractor
    {
        public Guid GetUserIdFromContext(HttpContext context);
    }
}
