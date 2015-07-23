using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox2.OS.Win32.PInvoke
{
	public static class Win32API
	{
		public delegate IntPtr WndProc(IntPtr hWnd, WindowsMessages msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern IntPtr DefWindowProc(IntPtr hWnd, WindowsMessages uMsg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern ushort RegisterClass([In] ref WNDCLASS lpWndClass);

		/// <summary>
		/// The CreateWindowEx function creates an overlapped, pop-up, or child window with an extended window style; otherwise, this function is identical to the CreateWindow function.
		/// </summary>
		/// <param name="dwExStyle">Specifies the extended window style of the window being created.</param>
		/// <param name="lpClassName">Pointer to a null-terminated string or a class atom created by a previous call to the RegisterClass or RegisterClassEx function. The atom must be in the low-order word of lpClassName; the high-order word must be zero. If lpClassName is a string, it specifies the window class name. The class name can be any name registered with RegisterClass or RegisterClassEx, provided that the module that registers the class is also the module that creates the window. The class name can also be any of the predefined system class names.</param>
		/// <param name="lpWindowName">Pointer to a null-terminated string that specifies the window name. If the window style specifies a title bar, the window title pointed to by lpWindowName is displayed in the title bar. When using CreateWindow to create controls, such as buttons, check boxes, and static controls, use lpWindowName to specify the text of the control. When creating a static control with the SS_ICON style, use lpWindowName to specify the icon name or identifier. To specify an identifier, use the syntax "#num". </param>
		/// <param name="dwStyle">Specifies the style of the window being created. This parameter can be a combination of window styles, plus the control styles indicated in the Remarks section.</param>
		/// <param name="x">Specifies the initial horizontal position of the window. For an overlapped or pop-up window, the x parameter is the initial x-coordinate of the window's upper-left corner, in screen coordinates. For a child window, x is the x-coordinate of the upper-left corner of the window relative to the upper-left corner of the parent window's client area. If x is set to CW_USEDEFAULT, the system selects the default position for the window's upper-left corner and ignores the y parameter. CW_USEDEFAULT is valid only for overlapped windows; if it is specified for a pop-up or child window, the x and y parameters are set to zero.</param>
		/// <param name="y">Specifies the initial vertical position of the window. For an overlapped or pop-up window, the y parameter is the initial y-coordinate of the window's upper-left corner, in screen coordinates. For a child window, y is the initial y-coordinate of the upper-left corner of the child window relative to the upper-left corner of the parent window's client area. For a list box y is the initial y-coordinate of the upper-left corner of the list box's client area relative to the upper-left corner of the parent window's client area.
		/// <para>If an overlapped window is created with the WS_VISIBLE style bit set and the x parameter is set to CW_USEDEFAULT, then the y parameter determines how the window is shown. If the y parameter is CW_USEDEFAULT, then the window manager calls ShowWindow with the SW_SHOW flag after the window has been created. If the y parameter is some other value, then the window manager calls ShowWindow with that value as the nCmdShow parameter.</para></param>
		/// <param name="nWidth">Specifies the width, in device units, of the window. For overlapped windows, nWidth is the window's width, in screen coordinates, or CW_USEDEFAULT. If nWidth is CW_USEDEFAULT, the system selects a default width and height for the window; the default width extends from the initial x-coordinates to the right edge of the screen; the default height extends from the initial y-coordinate to the top of the icon area. CW_USEDEFAULT is valid only for overlapped windows; if CW_USEDEFAULT is specified for a pop-up or child window, the nWidth and nHeight parameter are set to zero.</param>
		/// <param name="nHeight">Specifies the height, in device units, of the window. For overlapped windows, nHeight is the window's height, in screen coordinates. If the nWidth parameter is set to CW_USEDEFAULT, the system ignores nHeight.</param> <param name="hWndParent">Handle to the parent or owner window of the window being created. To create a child window or an owned window, supply a valid window handle. This parameter is optional for pop-up windows.
		/// <para>Windows 2000/XP: To create a message-only window, supply HWND_MESSAGE or a handle to an existing message-only window.</para></param>
		/// <param name="hMenu">Handle to a menu, or specifies a child-window identifier, depending on the window style. For an overlapped or pop-up window, hMenu identifies the menu to be used with the window; it can be NULL if the class menu is to be used. For a child window, hMenu specifies the child-window identifier, an integer value used by a dialog box control to notify its parent about events. The application determines the child-window identifier; it must be unique for all child windows with the same parent window.</param>
		/// <param name="hInstance">Handle to the instance of the module to be associated with the window.</param> <param name="lpParam">Pointer to a value to be passed to the window through the CREATESTRUCT structure (lpCreateParams member) pointed to by the lParam param of the WM_CREATE message. This message is sent to the created window by this function before it returns.
		/// <para>If an application calls CreateWindow to create a MDI client window, lpParam should point to a CLIENTCREATESTRUCT structure. If an MDI client window calls CreateWindow to create an MDI child window, lpParam should point to a MDICREATESTRUCT structure. lpParam may be NULL if no additional data is needed.</para></param>
		/// <returns>If the function succeeds, the return value is a handle to the new window.
		/// <para>If the function fails, the return value is NULL. To get extended error information, call GetLastError.</para>
		/// <para>This function typically fails for one of the following reasons:</para>
		/// <list type="">
		/// <item>an invalid parameter value</item>
		/// <item>the system class was registered by a different module</item>
		/// <item>The WH_CBT hook is installed and returns a failure code</item>
		/// <item>if one of the controls in the dialog template is not registered, or its window window procedure fails WM_CREATE or WM_NCCREATE</item>
		/// </list></returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr CreateWindowEx(uint dwExStyle, string lpClassName, string lpWindowName,
		   WindowStyles dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu,
		   IntPtr hInstance, IntPtr lpParam);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
		   uint wMsgFilterMax, uint wRemoveMsg);

		[DllImport("user32.dll")]
		public static extern sbyte GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
		   uint wMsgFilterMax);

		[DllImport("user32.dll")]
		public static extern bool TranslateMessage([In] ref MSG lpMsg);

		[DllImport("user32.dll")]
		public static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

		/// <summary>
		/// <para>The DestroyWindow function destroys the specified window. The function sends WM_DESTROY and WM_NCDESTROY messages to the window to deactivate it and remove the keyboard focus from it. The function also destroys the window's menu, flushes the thread message queue, destroys timers, removes clipboard ownership, and breaks the clipboard viewer chain (if the window is at the top of the viewer chain).</para>
		/// <para>If the specified window is a parent or owner window, DestroyWindow automatically destroys the associated child or owned windows when it destroys the parent or owner window. The function first destroys child or owned windows, and then it destroys the parent or owner window.</para>
		/// <para>DestroyWindow also destroys modeless dialog boxes created by the CreateDialog function.</para>
		/// </summary>
		/// <param name="hwnd">Handle to the window to be destroyed.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool DestroyWindow(IntPtr hwnd);

		/// <summary>
		/// Unregisters a window class, freeing the memory required for the class.
		/// </summary>
		/// <param name="lpClassName">
		/// Type: LPCTSTR
		/// A null-terminated string or a class atom. If lpClassName is a string, it specifies the window class name.
		/// This class name must have been registered by a previous call to the RegisterClass or RegisterClassEx function.
		/// System classes, such as dialog box controls, cannot be unregistered. If this parameter is an atom,
		///   it must be a class atom created by a previous call to the RegisterClass or RegisterClassEx function.
		/// The atom must be in the low-order word of lpClassName; the high-order word must be zero.
		///
		/// </param>
		/// <param name="hInstance">
		/// A handle to the instance of the module that created the class.
		///
		/// </param>
		/// <returns>
		/// Type: BOOL
		/// If the function succeeds, the return value is nonzero.
		/// If the class could not be found or if a window still exists that was created with the class, the return value is zero.
		/// To get extended error information, call GetLastError.
		///
		/// </returns>
		[DllImport("user32.dll")]
		public static extern bool UnregisterClass(string lpClassName, IntPtr hInstance);

		[DllImport("user32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("Gdi32.dll")]
		public static extern int ChoosePixelFormat(IntPtr hdc, ref PixelFormatDescriptor pfd);

		[DllImport("Gdi32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetPixelFormat(IntPtr hdc, int iPixelFormat, ref PixelFormatDescriptor pfd);

		[DllImport("user32.dll")]
		public static extern void PostQuitMessage(int nExitCode);
	}
}
