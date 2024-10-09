using Serilog;

namespace Dtx.Logging
{
    public class SerilogAdapter<T> : Logger<T>
    {
        public SerilogAdapter(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        protected override void LogByFavoriteLibrary(Log log, System.Exception exception)
        {
            var logger = Log.ForContext<T>();

            switch (log.Level)
            {
                case LogLevel.Trace:
                    logger.Verbose(exception, log.ToString());
                    break;

                case LogLevel.Debug:
                    logger.Debug(exception, log.ToString());
                    break;

                case LogLevel.Information:
                    logger.Information(exception, log.ToString());
                    break;

                case LogLevel.Warning:
                    logger.Warning(exception, log.ToString());
                    break;

                case LogLevel.Error:
                    logger.Error(exception, log.ToString());
                    break;

                case LogLevel.Critical:
                    logger.Fatal(exception, log.ToString());
                    break;
            }
        }
    }
}
