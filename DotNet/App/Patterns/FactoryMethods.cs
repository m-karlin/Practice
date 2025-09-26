namespace App.Patterns;

public class FactoryMethods
{
	private interface ILogger
	{
		void Log(string message);
	}

	private class FileLogger : ILogger
	{
		// запись в файл
		public void Log(string message) => Console.WriteLine(message);
	}

	private class ConsoleLogger : ILogger
	{
		public void Log(string message) => Console.WriteLine(message);
	}

	public class DatabaseLogger : ILogger
	{
		// запись в БД
		public void Log(string message) => Console.WriteLine(message);
	}

	private abstract class LoggerFactory
	{
		public abstract ILogger CreateLogger();

		public void LogMessage(string message)
		{
			var logger = CreateLogger();
			logger.Log(message);
		}
	}

	private class FileLoggerFactory : LoggerFactory
	{
		public override ILogger CreateLogger() => new FileLogger();
	}

	private class ConsoleLoggerFactory : LoggerFactory
	{
		public override ILogger CreateLogger() => new ConsoleLogger();
	}

	public static void Run()
	{
		LoggerFactory factory;

		//var loggerType = ConfigurationManager.AppSettings["LoggerType"];
		var loggerType = "Console";

		if (loggerType == "File")
			factory = new FileLoggerFactory();
		else
			factory = new ConsoleLoggerFactory();

		factory.LogMessage("Важное сообщение");
	}
}