using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	public enum MemoryModels
	{
		Simple = 0,
		GLSL450 = 1,
		OpenCL1_2 = 2,
		OpenCL2_0 = 3,
		OpenCL2_1 = 4,
		Unknown = -1,
	}
}
