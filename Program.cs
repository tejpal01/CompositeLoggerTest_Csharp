using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CompositeLoggerDemo.Logging;

namespace CompositeLoggerDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Define the file path for the log file
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            string logFilePath = Path.Combine(logDirectory, "app.log");

            // Ensure the Logs directory exists
            Directory.CreateDirectory(logDirectory);

            // Create individual loggers
            ICompositeLogger consoleLogger = new ConsoleLogger();
            ICompositeLogger fileLogger = new FileLogger(logFilePath);

            // Create the composite logger
            ICompositeLogger compositeLogger = new CompositeLogger(new List<ICompositeLogger> { consoleLogger, fileLogger });

            // Log messages asynchronously
            await compositeLogger.LogInformationAsync("Application started.");
            await compositeLogger.LogWarningAsync("This is a warning.");
            await compositeLogger.LogErrorAsync("An error occurred.", new Exception("Sample exception"));

            Console.WriteLine("\nLogging completed. Check the console and log file.");
        }
    }
}