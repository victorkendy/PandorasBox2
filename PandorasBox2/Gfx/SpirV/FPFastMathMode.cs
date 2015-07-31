using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	[Flags]
	public enum FPFastMathMode
	{
		None = 0x0,
		NotNaN = 0x1,
		NotInf = 0x2,
		NSZ = 0x4,
		AllowRecip = 0x8,
		Fast = 0x10,
		Unknown = -1,
	}
}
