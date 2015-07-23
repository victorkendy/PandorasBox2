using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Logging
{
	public interface ILog
	{
		void Debug(String message, params Object[] args);

		void Info(String message, params Object[] args);

		void Warn(String message, params Object[] args);

		void Error(String message, params Object[] args);

		void Fatal(String message, params Object[] args);
	}
}
