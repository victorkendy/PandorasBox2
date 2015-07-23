using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.OS
{
	public interface IMessagePump
	{
		IMessageDispatcher Dispatcher { get; }

		void PumpMessages();
	}
}
