using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox2.OS.Win32.PInvoke
{
	[StructLayout(LayoutKind.Sequential)]
	public struct MSG
	{
		public IntPtr hwnd;
		public WindowsMessages message;
		public IntPtr wParam;
		public IntPtr lParam;
		public UInt32 time;
		public POINT pt;
	}
}
