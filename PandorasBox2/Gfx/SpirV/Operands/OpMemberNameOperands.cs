using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	class OpMemberNameOperands : AbstractOperandInterpreter
	{
		internal override object[] Interpret(int[] words)
		{
			return new Object[] { words[0], words[1], ReadString(words, 2) };
		}
	}
}
