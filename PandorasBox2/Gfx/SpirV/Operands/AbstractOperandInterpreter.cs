using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	abstract class AbstractOperandInterpreter
	{
		internal abstract Object[] Interpret(int[] words);

		protected String ReadString(int[] words, int offset)
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

		protected T ReadEnum<T>(int word, T defaultValue) where T : struct, IConvertible
		{
			Object possibleValue = Enum.ToObject(typeof(T), word);
			if (Enum.IsDefined(typeof(T), possibleValue)) return (T) possibleValue;
			return defaultValue;
		}

		protected T? ReadEnum<T>(int word) where T : struct, IConvertible
		{
			Object possibleValue = Enum.ToObject(typeof(T), word);
			if (Enum.IsDefined(typeof(T), possibleValue)) return (T)possibleValue;
			return null;
		}
	}
}
