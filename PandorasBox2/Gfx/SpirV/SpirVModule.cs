using PandorasBox.Gfx.SpirV.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandorasBox.Gfx.SpirV
{
	public class SpirVModule
	{
		private SpirVModuleHeader header;
		private List<Instruction> instructions;

		internal SpirVModule(SpirVModuleHeader header, List<Instruction> instructions)
		{
			this.header = header;
			this.instructions = instructions;
		}

		public List<ShaderFunction> GetFunctions()
		{
			return null;
		}

		public ShaderFunction GetEntryPoint()
		{
			return null;
		}
	}
}
