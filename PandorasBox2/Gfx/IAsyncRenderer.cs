using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx
{
	public interface IAsyncRenderer
	{
		void Start();

		void Stop();

		void ChangeTasks(IList<IGPUTask> tasks);
	}
}
