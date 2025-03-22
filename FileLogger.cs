using System;
using System.IO;

namespace CompositeLoggerTest.Logging
{
   public class FileLogger : ICompositeLogger
     {
	private readonly string _filePath;
	public FileLogger(string filepPath)
	{
	   _filePath= filePath;
	}
	public async Task WriteToFileAsync(string logMessage)
	{
	   try
	    {
		using(StreamWriter writer = new StreamWriter(_filePath, true))
		{
		  await writer.WriteLineAsync($"{DateTime.Now} : {logMessage}");
		}
	    }
           catch(Exception ex)
	   {
   	     Console.WriteLine($"[FileLogger Error] {ex.Message}");
	   }
	}
	public Task LoginformationAsync(string message) => WriteToFileAsync($"[INFO] {message}");
	public Task LogWarningAsync(string message) => WriteToFileAsync($"[WARN] {message}");
	public Task LoginformationAsync(string message, Exception? ex = null) => WriteToFileAsync($"[ERROR] {message} {ex?.message}");
     }
}