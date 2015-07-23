using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx
{
	public interface IGPUTaskFactory
	{
		IGPUTask ClearBuffers();

		IGPUTask RenderSomething();

		IGPUTask SwapBuffers();
	}
}
