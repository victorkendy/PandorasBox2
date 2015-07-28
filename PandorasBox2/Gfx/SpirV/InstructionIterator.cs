using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	internal class InstructionIterator
	{
		private System.IO.BinaryReader reader;

		internal InstructionIterator(System.IO.BinaryReader reader)
		{
			this.reader = reader;
		}

		internal Instruction Next()
		{
			int? word = nextWord();
			if (word.HasValue)
			{
				int numberOfWords = word.Value >> 16;
				int opcode = word.Value & 0xFFFF;
				SpirVOpcodes spirvOpcode = (SpirVOpcodes)opcode;
				if (!Enum.IsDefined(typeof(SpirVOpcodes), spirvOpcode))
				{
					spirvOpcode = SpirVOpcodes.OpUnknown;
				}
				Console.WriteLine(numberOfWords);
				return new Instruction(spirvOpcode, opcode, reader.ReadBytes((numberOfWords - 1) * 4));
			}
			return null;
		}

		private int? nextWord()
		{
			byte[] bytes = reader.ReadBytes(4);
			if (bytes.Length == 0) return null;
			return BitConverter.ToInt32(bytes, 0);
		}
	}
}
