using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	class OpEntryPointOperands : AbstractOperandInterpreter
	{
		internal override object[] Interpret(int[] words)
		{
			return new Object[] { ReadEnum(words[0], ExecutionModels.Unknown), words[1] };
		}
	}
}
