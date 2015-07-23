using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandorasBox.Gfx
{
	public interface IWindow : IDisposable
	{
		void Show();

		IGraphicDriver GraphicDriver { get; }

		IAsyncRenderer Renderer { get; }
	}
}
