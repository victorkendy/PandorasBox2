using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Gfx;
using PandorasBox2.OS.Win32.PInvoke;

namespace PandorasBox.OS.Win32
{
	public class WindowFactory : IDisposable
	{
		private static readonly string WndClassName = "__PandorasBox2__WNDCLASS";
		private IntPtr hInstance;
		private bool disposed;
		private IGraphicDriverFactory driverFactory;

		public WindowFactory(IGraphicDriverFactory factory)
		{
			this.driverFactory = factory;
			this.hInstance = Process.GetCurrentProcess().Handle;
			WNDCLASS wnd = default(WNDCLASS);
			wnd.style = ClassStyles.OwnDC | ClassStyles.VerticalRedraw | ClassStyles.HorizontalRedraw;
			wnd.lpfnWndProc = MessageHandler;
			wnd.cbClsExtra = 0;
			wnd.cbWndExtra = 0;
			wnd.hInstance = hInstance;
			wnd.hCursor = Win32API.LoadCursor(IntPtr.Zero, 32512);
			//wnd.hbrBackground = new IntPtr(6);
			wnd.lpszClassName = WndClassName;

			ushort result = Win32API.RegisterClass(ref wnd);
			if (result == 0)
			{
				// TODO: throw system error
			}
		}

		public IWindow CreateWindow(WindowConfiguration cfg)
		{
			WindowStyles styles = WindowStyles.WS_OVERLAPPEDWINDOW | WindowStyles.WS_CLIPCHILDREN | WindowStyles.WS_CLIPSIBLINGS;
			IntPtr hWnd = Win32API.CreateWindowEx(0, WndClassName, cfg.Title, styles, 800, 100, cfg.Width, cfg.Height, IntPtr.Zero, IntPtr.Zero, hInstance, IntPtr.Zero);
			//if (IntPtr.Zero.Equals(hWnd))
			//{
			//	throw new Win32Exception("Failed to create a new window");
			//}
			IntPtr hDC = Win32API.GetDC(hWnd);
			IGraphicDriver driver = driverFactory.CreateDriver(hWnd, hDC);
			return new Win32Window(hWnd, hDC, driver, new DefaultAsyncRenderer(driver));
		}

		public void Dispose()
		{
			if (!disposed)
			{
				Win32API.UnregisterClass(WndClassName, hInstance);
				GC.SuppressFinalize(this);
			}
			disposed = true;
		}

		// System Message Handler
		private static IntPtr MessageHandler(IntPtr hWnd, WindowsMessages msg, IntPtr wParam, IntPtr lParam)
		{
			switch (msg)
			{
				case WindowsMessages.CLOSE:
					Win32API.PostQuitMessage(0);
					break;
			}
			IntPtr result = Win32API.DefWindowProc(hWnd, msg, wParam, lParam);
			return result;
		}
	}
}
