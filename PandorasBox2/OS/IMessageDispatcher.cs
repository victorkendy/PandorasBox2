using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.OS
{
	public interface IMessageDispatcher
	{
		void DispatchQuitMessage();

		void DispatchWindowResize(int newWidth, int newHeight);

		void DispatchKeyboardPress(char key);

		void DispatchKeyboardRelease(char key);
	}
}
