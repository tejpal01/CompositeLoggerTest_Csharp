namespace CompositeLoggerTest.Logging
{
	public interface ICompositeLogger
	{
	   void LogInformationAsync(string message);
	   void LogWarningAsync(string message);
	   void LogErrorAsync(string message, Exception? ex = null);
	}
}