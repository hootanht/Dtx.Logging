namespace Dtx.Logging
{
	public class Log4NetAdapter<T> : Logger<T>
	{
		public Log4NetAdapter
			(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
		{
		}

		protected override void LogByFavoriteLibrary(Log log, System.Exception exception)
		{
			log4net.ILog logger = log4net.LogManager.GetLogger(typeof(T));

			switch (log.Level)
			{
				case LogLevel.Trace:
					logger.Debug(log.ToString(), exception);
					break;

				case LogLevel.Debug:
					logger.Debug(log.ToString(), exception);
					break;

				case LogLevel.Information:
					logger.Info(log.ToString(), exception);
					break;

				case LogLevel.Warning:
					logger.Warn(log.ToString(), exception);
					break;

				case LogLevel.Error:
					logger.Error(log.ToString(), exception);
					break;

				case LogLevel.Critical:
					logger.Fatal(log.ToString(), exception);
					break;
			}
		}
	}
}
