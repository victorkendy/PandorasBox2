using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	internal class InstructionIterator
	{
		private WordReader reader;

		internal InstructionIterator(WordReader reader)
		{
			this.reader = reader;
		}

		internal Instruction Next()
		{
			int? word = reader.ReadWord();
			if (word.HasValue)
			{
				int numberOfWords = word.Value >> 16;
				int opcode = word.Value & 0xFFFF;
				SpirVOpcodes spirvOpcode = (SpirVOpcodes)opcode;
				if (!Enum.IsDefined(typeof(SpirVOpcodes), spirvOpcode))
				{
					spirvOpcode = SpirVOpcodes.OpUnknown;
				}
				Object[] operands = OperandInterpreter.GetOperands(spirvOpcode, reader.ReadWords(numberOfWords - 1));
				return new Instruction(spirvOpcode, opcode, operands);
			}
			return null;
		}
	}
}
