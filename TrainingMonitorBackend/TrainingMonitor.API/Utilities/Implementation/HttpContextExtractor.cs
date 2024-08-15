using TrainingMonitor.API.Utilities.Interface;

namespace TrainingMonitor.API.Utilities.Implementation
{
    public class HttpContextExtractor : IHttpContextExtractor
    {

        public HttpContextExtractor()
        {
        }
        public Guid GetUserIdFromContext(HttpContext context)
        {
            try
            {
                foreach (var claim in context.User.Claims)
                {
                    if (claim.Type == "id")
                    {
                        return Guid.Parse(claim.Value);
                    }
                }

                return Guid.Empty;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
