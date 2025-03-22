using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompositeLoggerDemo.Logging
{
    public class CompositeLogger : ICompositeLogger
    {
        private readonly IEnumerable<ICompositeLogger> _loggers;

        public CompositeLogger(IEnumerable<ICompositeLogger> loggers)
        {
            _loggers = loggers;
        }

        public async Task LogInformationAsync(string message)
        {
            var tasks = new List<Task>();
            foreach (var logger in _loggers)
            {
                tasks.Add(logger.LogInformationAsync(message));
            }
            await Task.WhenAll(tasks);
        }

        public async Task LogWarningAsync(string message)
        {
            var tasks = new List<Task>();
            foreach (var logger in _loggers)
            {
                tasks.Add(logger.LogWarningAsync(message));
            }
            await Task.WhenAll(tasks);
        }

        public async Task LogErrorAsync(string message, Exception? ex = null)
        {
            var tasks = new List<Task>();
            foreach (var logger in _loggers)
            {
                tasks.Add(logger.LogErrorAsync(message, ex));
            }
            await Task.WhenAll(tasks);
        }
    }
}