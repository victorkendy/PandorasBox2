using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox2.OS.Win32.OpenGL
{
	public class WGL
	{

		[DllImport("OpenGL32.dll", EntryPoint = "wglCreateContext")]
		public static extern IntPtr CreateContext(IntPtr hdc);

		[DllImport("OpenGL32.dll", EntryPoint = "wglMakeCurrent")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MakeCurrent(IntPtr hdc, IntPtr hglrc);

		[DllImport("OpenGL32.dll", EntryPoint = "wglDeleteContext")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DeleteContext(IntPtr hglrc);

		[DllImport("OpenGL32.dll", EntryPoint = "wglGetProcAddress")]
		public static extern IntPtr GetProcAddress(string name);

		[DllImport("gdi32.dll")]
		public static extern bool SwapBuffers(IntPtr hdc);
	}
}
