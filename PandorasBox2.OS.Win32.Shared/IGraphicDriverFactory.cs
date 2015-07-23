using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Gfx;

namespace PandorasBox.OS.Win32
{
	public interface IGraphicDriverFactory
	{
		IGraphicDriver CreateDriver(IntPtr hWnd, IntPtr hDC);
	}
}
