
namespace Sheenam.MVC.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger logger;

        public LoggingBroker(ILogger logger) =>
            logger = logger;

        public void LogError(Exception exception) =>
            this.logger.LogError(exception,exception.Message);

        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception,exception.Message);
    }
}
