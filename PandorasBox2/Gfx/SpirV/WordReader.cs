using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	// TODO: handle endianess
	internal class WordReader : IDisposable
	{
		private BinaryReader reader;

		public WordReader(Stream stream)
		{
			this.reader = new BinaryReader(stream);
		}

		public int? ReadWord()
		{
			byte[] bytes = reader.ReadBytes(4);
			if (bytes.Length > 0) 
			{
				return BitConverter.ToInt32(bytes, 0);
			}
			return null;
		}

		public int[] ReadWords(int count)
		{
			int[] words = new int[count];
			for (int i = 0; i < count; i++)
			{
				int? nextWord = ReadWord();
				if (nextWord.HasValue)
				{
					words[i] = nextWord.Value;
				}
				else
				{
					throw new IndexOutOfRangeException("End of stream");
				}
			}
			return words;
		}

		public void Dispose()
		{
			reader.Dispose();
		}
	}
}
