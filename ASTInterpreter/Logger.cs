using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace ASTInterpreter
{
	public static class Logger
	{
		private static readonly ILogger _logger;

		static Logger()
		{
			ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
			{
				builder.AddConsole();
			});
			_logger = loggerFactory.CreateLogger("AstInterpreter");
		}

		public static void Info(string message)
		{
			_logger.LogInformation(message);
		}
		public static void Warn(string message)
		{
			_logger.LogWarning(message);
		}
		public static void Error(string message)
		{
			_logger.LogError(message);
		}
	}
}
