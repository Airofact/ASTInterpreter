using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

namespace ASTInterpreter
{
	internal class Logger
	{
		private static ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
		{
			builder.AddConsole();
		});

		public static ILogger<T> CreateLogger<T>() => loggerFactory.CreateLogger<T>();
	}
}
