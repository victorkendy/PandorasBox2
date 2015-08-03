using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandorasBox.Gfx.SpirV
{
	class SpirVModuleHeader
	{
		private int magicNumber;
		private int version;
		private int generatorIdentifier;
		private int boundIds;
		private int schema;

		internal SpirVModuleHeader(int magicNumber, int version, int generatorIdentifier, int boundIds, int schema)
		{
			this.magicNumber = magicNumber;
			this.version = version;
			this.generatorIdentifier = generatorIdentifier;
			this.boundIds = boundIds;
			this.schema = schema;
		}
	}
}
