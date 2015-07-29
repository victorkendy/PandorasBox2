using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	static class OperandInterpreter
	{
		public static Object[] GetOperands(SpirVOpcodes opcode, int[] words)
		{
			Object[] operands = null;
			if (SpirVOpcodes.OpSource == opcode)
			{
				operands = new Object[2];
				SourceLanguages source = (SourceLanguages) words[0];
				if (!Enum.IsDefined(typeof(SourceLanguages), source)) source = SourceLanguages.Unknown;
				operands[0] = source;
				operands[1] = words[1];
			}
			else if (SpirVOpcodes.OpMemoryModel == opcode)
			{
				operands = new Object[2];
				AddressingModels addressing = (AddressingModels)words[0];
				if (!Enum.IsDefined(typeof(AddressingModels), addressing)) addressing = AddressingModels.Unknown;
				MemoryModels model = (MemoryModels)words[1];
				if (!Enum.IsDefined(typeof(MemoryModels), model)) model = MemoryModels.Unknown;
				operands[0] = addressing;
				operands[1] = model;
			}
			else if (SpirVOpcodes.OpEntryPoint == opcode)
			{
				operands = new Object[2];
				ExecutionModels model = (ExecutionModels)words[0];
				if (!Enum.IsDefined(typeof(ExecutionModels), model)) model = ExecutionModels.Unknown;
				operands[0] = model;
				operands[1] = words[1];
			}
			else if (SpirVOpcodes.OpName == opcode)
			{
				operands = new Object[2];
				operands[0] = words[0];
				operands[1] = readString(words, 1);
			}
			else
			{
				operands = Array.ConvertAll<int, Object>(words, x => x);
			}
			return operands;
		}

		private static object readString(int[] words, int offset)
		{
			StringBuilder builder = new StringBuilder(4 * (words.Length - offset));
			for (int i = offset; i < words.Length; i++)
			{
				int j = 0;
				char letter;
				do
				{
					letter = (char)((words[i] >> (j * 8)) & 0xFF);
					if (letter == '\0') break;
					builder.Append(letter);
					j++;
				} while (letter != 0 && j < 4);
			}
			return builder.ToString();
		}
	}
}
