using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	class OpSourceOperands : AbstractOperandInterpreter
	{
		internal override object[] Interpret(int[] words)
		{
			return new Object[] { ReadEnum<SourceLanguages>(words[0], SourceLanguages.Unknown), words[1] };
		}
	}
}
