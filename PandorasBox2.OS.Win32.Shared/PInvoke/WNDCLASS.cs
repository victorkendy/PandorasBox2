using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox2.OS.Win32.PInvoke
{
	[StructLayout(LayoutKind.Sequential)]
	public struct WNDCLASS
	{
		public ClassStyles style;
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PandorasBox2.OS.Win32.PInvoke.Win32API.WndProc lpfnWndProc;
		public int cbClsExtra;
		public int cbWndExtra;
		public IntPtr hInstance;
		public IntPtr hIcon;
		public IntPtr hCursor;
		public IntPtr hbrBackground;

		public string lpszMenuName;

		public string lpszClassName;
	}
}
