using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Gfx;
using PandorasBox.Logging;
using PandorasBox.OpenGL;
using PandorasBox.OpenGL.PInvoke;
using PandorasBox2.OS.Win32.OpenGL;
using PandorasBox2.OS.Win32.PInvoke;

namespace PandorasBox.OS.Win32.OpenGL
{
	public class GLGraphicDriverFactory : IGraphicDriverFactory
	{
		private const int WGL_CONTEXT_MAJOR_VERSION_ARB = 0x2091;
		private const int WGL_CONTEXT_MINOR_VERSION_ARB = 0x2092;
		private const int WGL_CONTEXT_FLAGS_ARB = 0x2094;
		private const int WGL_CONTEXT_PROFILE_MASK_ARB = 0x9126;

		private const int WGL_CONTEXT_FORWARD_COMPATIBLE_BIT_ARB = 0x0002;
		private const int WGL_CONTEXT_CORE_PROFILE_BIT_ARB = 0x00000001;

		delegate IntPtr WGLCreateContextAttribsDelegate(IntPtr hDC, IntPtr layers, int[] attributes);

		private ILog logger = Logger.Get<GLGraphicDriverFactory>();
		private IntPtr hInstance = Process.GetCurrentProcess().Handle;

		private Func<IntPtr, IntPtr> contextCreator = null;

		public IGraphicDriver CreateDriver(IntPtr hWnd, IntPtr hDC)
		{
			PixelFormatDescriptor pfd = PixelFormatDescriptor.DefaultFormat();

			int pixelFormat = Win32API.ChoosePixelFormat(hDC, ref pfd);
			if (pixelFormat == 0)
			{
				logger.Fatal("invalid pixel format");
			}
			Win32API.SetPixelFormat(hDC, pixelFormat, ref pfd);

			IntPtr hglrc = IntPtr.Zero;
			if (contextCreator == null)
			{
				logger.Debug("Instantiating Legacy GL Context");
				hglrc = WGL.CreateContext(hDC);

				// validate
				WGL.MakeCurrent(hDC, hglrc);
				String glVersionString = Marshal.PtrToStringAnsi(GL.GetString(GLStringNames.GL_VERSION));
				logger.Info("Legacy Version: {0}", glVersionString);
				OpenGLInfo info = new OpenGLInfo(glVersionString);

				IntPtr wglCreateContextAttribsPtr = WGL.GetProcAddress("wglCreateContextAttribsARB");
				if (wglCreateContextAttribsPtr != IntPtr.Zero && false) // TODO: support core profile
				{
					logger.Debug("WGL_create_context is supported");
					WGLCreateContextAttribsDelegate wglCreateContextAttribs = (WGLCreateContextAttribsDelegate)
						Marshal.GetDelegateForFunctionPointer(wglCreateContextAttribsPtr, typeof(WGLCreateContextAttribsDelegate));

					contextCreator = (deviceContextHandle) =>
					{
						// try to get the greater version possible
						int[] attributes = 
						{
							WGL_CONTEXT_MAJOR_VERSION_ARB, info.MajorVersion,
							WGL_CONTEXT_MINOR_VERSION_ARB, info.MinorVersion,
							WGL_CONTEXT_FLAGS_ARB, WGL_CONTEXT_FORWARD_COMPATIBLE_BIT_ARB,
							WGL_CONTEXT_PROFILE_MASK_ARB, WGL_CONTEXT_CORE_PROFILE_BIT_ARB,
						};
						// TODO: validate before returning
						return wglCreateContextAttribs(deviceContextHandle, IntPtr.Zero, attributes);
					};

					WGL.MakeCurrent(hDC, IntPtr.Zero);
					WGL.DeleteContext(hglrc);
					hglrc = contextCreator(hDC);
				}
				else
				{
					contextCreator = (deviceContextHandle) =>
					{
						return WGL.CreateContext(deviceContextHandle);
					};
				}
			}
			else
			{
				hglrc = contextCreator(hDC);
			}
			
			if (IntPtr.Zero.Equals(hglrc))
			{
				logger.Fatal("Context instantiation failed");
			}
			return new GLGraphicDriver(hglrc, hDC);
		}
	}
}
