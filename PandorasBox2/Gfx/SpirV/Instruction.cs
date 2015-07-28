using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandorasBox.Gfx.SpirV
{
	public class Instruction
	{
		private int opcode;
		private SpirVOpcodes spirvOpcode;
		private byte[] operands;

		internal Instruction(SpirVOpcodes spirvOpcode, int opcode, byte[] operands)
		{
			this.spirvOpcode = spirvOpcode;
			this.opcode = opcode;
			this.operands = operands;
		}
		public SpirVOpcodes OpCode { get; private set; }

		public int OpCodeNumber { get; private set; }

		public override string ToString()
		{
			return String.Format("{0}: {1}", opcode, spirvOpcode);
		}
	}
}
