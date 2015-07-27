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
			using(BinaryReader reader = new BinaryReader(fileStream))
			{
				SpirVModuleHeader header = ReadModuleHeader(reader.ReadBytes(20));
				return new SpirVModule(header);
			}
		}

		private SpirVModuleHeader ReadModuleHeader(byte[] bytes)
		{
			// TODO: handle endianess
			int magicNumber = BitConverter.ToInt32(bytes, 0);
			if (magicNumber != MagicNumber)
			{
				throw new ArgumentException("invalid shader program");
			}
			int version = BitConverter.ToInt32(bytes, 4);
			int generatorIdentifier = BitConverter.ToInt32(bytes, 8);
			int boundIds = BitConverter.ToInt32(bytes, 12);
			int schema = BitConverter.ToInt32(bytes, 16);

			logger.Debug("Magic Number = {0:X}\nVersion = {1}\nGenerator Identifier={2}\nids = {3}\nschema= {4}\n", 
				magicNumber, version, generatorIdentifier, boundIds, schema);

			return new SpirVModuleHeader(magicNumber, version, generatorIdentifier, boundIds, schema);
		}
	}
}
