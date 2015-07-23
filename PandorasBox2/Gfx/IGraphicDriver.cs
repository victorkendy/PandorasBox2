using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandorasBox.Gfx
{
	public interface IGraphicDriver : IDisposable
	{
		void Bind();

		void OnRenderStarting();

		void Unbind();

		IGPUTaskFactory TaskFactory { get; }

		GPUState State { get; }
	}
}
