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
		private Object[] operands;

		internal Instruction(SpirVOpcodes spirvOpcode, int opcode, Object[] operands)
		{
			this.spirvOpcode = spirvOpcode;
			this.opcode = opcode;
			this.operands = operands;
		}
		public SpirVOpcodes OpCode { get; private set; }

		public int OpCodeNumber { get; private set; }

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder().AppendFormat("{0}: {1} [", opcode, spirvOpcode);
			foreach(Object operand in operands) 
			{
				builder.AppendFormat("{0},", operand);
			}
			builder.Append("]");

			return builder.ToString();
		}
	}
}
