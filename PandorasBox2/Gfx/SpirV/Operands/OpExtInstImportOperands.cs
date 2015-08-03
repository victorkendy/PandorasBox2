using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	class OpExtInstImportOperands : AbstractOperandInterpreter
	{
		internal override object[] Interpret(int[] words)
		{
			return new Object[] { words[0], ReadString(words, 1) };
		}
	}
}
