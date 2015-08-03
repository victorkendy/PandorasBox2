using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	class NoInterpretation : AbstractOperandInterpreter
	{
		internal override object[] Interpret(int[] words)
		{
			return Array.ConvertAll<int, Object>(words, x => x) ;
		}
	}
}
