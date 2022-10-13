namespace SelfieAWookieAPI.Middlewares
{
    public class LogRequestMiddleware
    {
        #region Fields
        private RequestDelegate _next = null;
        private ILogger<LogRequestMiddleware> _logger = null;
        #endregion

        #region Constructors
        public LogRequestMiddleware(RequestDelegate next, ILogger<LogRequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        #endregion

        #region Public Methods
        public async Task Invoke(HttpContext context)
        {
            _logger.LogDebug(context.Request.Path.Value);

            await _next(context);
        }
        #endregion
    }
}
