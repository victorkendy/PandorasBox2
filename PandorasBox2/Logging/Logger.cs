using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Logging
{
	public class Logger
	{
		public static ILog Get<T>()
		{
			return Log4NetLogger.Create<T>();
		}
	}
}
