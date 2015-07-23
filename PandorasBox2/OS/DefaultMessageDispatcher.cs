using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Logging;

namespace PandorasBox.OS
{
	public class DefaultMessageDispatcher : IMessageDispatcher
	{
		ILog logger = Logger.Get<DefaultMessageDispatcher>();
		public void DispatchQuitMessage()
		{
			logger.Info("Received quit message");
		}

		public void DispatchWindowResize(int newWidth, int newHeight)
		{
		}

		public void DispatchKeyboardPress(char key)
		{
		}

		public void DispatchKeyboardRelease(char key)
		{
		}
	}
}
