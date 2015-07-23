using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using PandorasBox.Gfx;
using PandorasBox.Logging;
using PandorasBox.OpenGL;
using PandorasBox.OpenGL.PInvoke;
using PandorasBox.OS.Win32.OpenGL.PInvoke;
using PandorasBox2.OS.Win32.OpenGL;

namespace PandorasBox.OS.Win32.OpenGL
{
	class GLGraphicDriver : AbstractGLGraphicDriver
	{
		private ILog logger = Logger.Get<GLGraphicDriver>();

		private IntPtr hglrc;
		private IntPtr hDC;
		private bool disposed;
		private OpenGLInfo info;
		private Win32GLTaskFactory taskFactory;

		public GLGraphicDriver(IntPtr hglrc, IntPtr hDC)
		{
			this.hglrc = hglrc;
			this.hDC = hDC;
			this.taskFactory = new Win32GLTaskFactory(this, hDC, hglrc);
			this.Bind();
			String versionString = Marshal.PtrToStringAnsi(GL.GetString(GLStringNames.GL_VERSION));
			this.info = new OpenGLInfo(versionString);
			logger.Info(versionString);
			this.Unbind();
		}

		public override void Bind()
		{
			WGL.MakeCurrent(hDC, hglrc);
		}

		public override void Unbind()
		{
			WGL.MakeCurrent(hDC, IntPtr.Zero);
		}

		public override void Dispose()
		{
			if (!disposed)
			{
				base.Dispose();
				Unbind();
				WGL.DeleteContext(hglrc);
				this.disposed = true;
				GC.SuppressFinalize(this);
			}
		}

		public override string ToString()
		{
			return this.info.ToString();
		}


		public override IGPUTaskFactory TaskFactory
		{
			get { return taskFactory; }
		}

		public override IntPtr GetGLEntryPoint(string entryPoint)
		{
			IntPtr functionPointer = WGL.GetProcAddress(entryPoint);
			if (IntPtr.Zero.Equals(functionPointer))
			{
				throw new ArgumentException("Invalid Entry Point: " + entryPoint);
			}
			return functionPointer;
		}
	}
}
