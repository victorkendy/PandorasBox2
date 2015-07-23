using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Logging
{
	class Log4NetLogger : ILog
	{
		private log4net.ILog logger;

		private Log4NetLogger(log4net.ILog logger) 
		{
			this.logger = logger;
		}

		internal static ILog Create<T>()
		{
			return new Log4NetLogger(log4net.LogManager.GetLogger(typeof(T)));
		}

		public void Info(string message, params object[] args)
		{
			logger.InfoFormat(message, args);
		}

		public void Warn(string message, params object[] args)
		{
			logger.WarnFormat(message, args);
		}

		public void Error(string message, params object[] args)
		{
			logger.ErrorFormat(message, args);
		}

		public void Fatal(string message, params object[] args)
		{
			logger.FatalFormat(message, args);
		}

		public void Debug(string message, params object[] args)
		{
			logger.DebugFormat(message, args);
		}
	}
}
