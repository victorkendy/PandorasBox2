using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx
{
	public interface IGPUTask
	{
		void Execute();

		bool ShouldExecute();

		GPUStateChange StateChange { get; }
	}
}
