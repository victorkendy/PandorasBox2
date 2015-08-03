using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	class OpMemoryModelOperands : AbstractOperandInterpreter
	{
		internal override object[] Interpret(int[] words)
		{
			return new Object[]
			{
				ReadEnum<AddressingModels>(words[0], AddressingModels.Unknown),
				ReadEnum<MemoryModels>(words[1], MemoryModels.Unknown)
			};
		}
	}
}
