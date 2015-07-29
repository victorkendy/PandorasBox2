using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Logging;

namespace PandorasBox.Gfx.SpirV
{
	public class ShaderLoader
	{
		ILog logger = Logger.Get<ShaderLoader>();

		private const int MagicNumber = 0x07230203;

		public SpirVModule Load(String fileName)
		{
			using(Stream fileStream = File.Open(fileName, FileMode.Open))
			using(WordReader reader = new WordReader(fileStream))
			{
				SpirVModuleHeader header = ReadModuleHeader(reader);
				var instructionIterator = new InstructionIterator(reader);
				List<Instruction> instructions = new List<Instruction>();
				Instruction instruction = instructionIterator.Next();
				while (instruction != null)
				{
					logger.Debug("{0}", instruction);
					instructions.Add(instruction);
					instruction = instructionIterator.Next();
				}
				return new SpirVModule(header, instructions);
			}
		}

		private SpirVModuleHeader ReadModuleHeader(WordReader reader)
		{
			int magicNumber = reader.ReadWord().Value;
			if (magicNumber != MagicNumber)
			{
				throw new ArgumentException("invalid shader program");
			}
			int version = reader.ReadWord().Value;
			int generatorIdentifier = reader.ReadWord().Value;
			int boundIds = reader.ReadWord().Value;
			int schema = reader.ReadWord().Value;

			logger.Debug("Magic Number = {0:X}\nVersion = {1}\nGenerator Identifier={2}\nids = {3}\nschema= {4}\n", 
				magicNumber, version, generatorIdentifier, boundIds, schema);

			return new SpirVModuleHeader(magicNumber, version, generatorIdentifier, boundIds, schema);
		}
	}
}
