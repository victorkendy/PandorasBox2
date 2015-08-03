using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	public enum FunctionParameterAttribute
	{
		Zext = 0,
		Sext = 1,
		ByVal = 2,
		Sret = 3,
		NoAlias = 4,
		NoCapture = 5,
		SVM = 6,
		NoWrite = 7,
		NoReadWrite = 8,
		Unknown = -1,
	}
}
