using System;
namespace CompositeLoggersTest.Logging
{
  public class ConsoleLogger : ICompositeLogger
    {
	public Task LogInformationAsync(string message)
	 {
            Console.ForegroundColor = ConsoleColor.Green;
	    Console.WriteLine($"[WARN] {message}");
            Console.ResetColor();
	    return Task.CompletedTask;
	 }
       public Task LogWarningAsync(string message)
       {
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine($"[WARN] {message}");
         Console.ResetColor();
	 return Task.CompletedTask;
       }
       public Task LogErrorAsync(string message, Exception ? ex = null)
	{
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] {message} {ex?.Message}");
            Console.ResetColor();
	    return Task.CompletedTask;
	}

    }
}