using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PandorasBox.Gfx;
using PandorasBox2.OS.Win32.PInvoke;

namespace PandorasBox.OS.Win32
{
	public class Win32Window : IWindow
	{
		private IntPtr hWnd;
		private IntPtr hDC;
		private bool disposed;
		private IGraphicDriver graphicDriver;
		private IAsyncRenderer asyncRenderer;

		public Win32Window(IntPtr hWnd, IntPtr hDC, IGraphicDriver graphicDriver, IAsyncRenderer asyncRenderer)
		{
			this.hWnd = hWnd;
			this.hDC = hDC;
			this.graphicDriver = graphicDriver;
			this.asyncRenderer = asyncRenderer;
		}

		public void Show()
		{
			this.asyncRenderer.Start();
			Win32API.ShowWindow(this.hWnd, 5);
		}

		public void Dispose()
		{
			if (!disposed) 
			{
				this.asyncRenderer.Stop();
				graphicDriver.Dispose();
				Win32API.DestroyWindow(this.hWnd);
				GC.SuppressFinalize(this);
				this.disposed = true;
			}			
		}

		public IGraphicDriver GraphicDriver { get { return this.graphicDriver; } }

		public IAsyncRenderer Renderer { get { return this.asyncRenderer; }	}
	}
}
