using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	public enum ExecutionModels
	{
		Vertex = 0,
		TesselationControl = 1,
		TesselationEvaluation = 2,
		Geometry = 3,
		Fragment = 4,
		GLCompute = 5,
		Kernel = 6,
		Unknown = -1,
	}
}
