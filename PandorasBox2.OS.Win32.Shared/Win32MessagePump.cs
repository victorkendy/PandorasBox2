using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox2.OS.Win32.PInvoke;

namespace PandorasBox.OS.Win32
{
	public class Win32MessagePump : IMessagePump
	{
		private IMessageDispatcher dispatcher;

		public Win32MessagePump(IMessageDispatcher dispatcher)
		{
			this.dispatcher = dispatcher;
		}

		public IMessageDispatcher Dispatcher
		{
			get { return this.dispatcher; }
		}

		public Win32MessagePump() : this (new DefaultMessageDispatcher()){}

		public void PumpMessages()
		{
			MSG msg = default(MSG);
			bool quit = false;

			while (!quit)
			{
				sbyte result = Win32API.GetMessage(out msg, IntPtr.Zero, 0, 0);

				if (result == 0 || result == -1 || msg.message == WindowsMessages.QUIT)
				{
					Dispatcher.DispatchQuitMessage();
					quit = true;
				}
				Win32API.TranslateMessage(ref msg);
				Win32API.DispatchMessage(ref msg);
			}
		}
	}
}
