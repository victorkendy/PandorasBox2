using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV.Operands
{
	class OpDecorateOperands : AbstractOperandInterpreter
	{
		static List<Decoration> DecorationsWithNumericOperator = new List<Decoration>
		{
			Decoration.Stream, Decoration.Location, Decoration.Component, Decoration.Index, Decoration.Binding, Decoration.DescriptorSet, Decoration.Offset,
			Decoration.Alignment, Decoration.XfbBuffer, Decoration.Stride, Decoration.SpecId
		};

		internal override object[] Interpret(int[] words)
		{
			Object[] operands = new Object[words.Length];
			operands[0] = words[0];
			Decoration decoration = ReadEnum<Decoration>(words[1]).Value;
			operands[1] = decoration;

			if(DecorationsWithNumericOperator.Contains(decoration))
			{
				operands[2] = words[2];
			}
			else if(decoration == Decoration.BuiltIn)
			{
				operands[2] = ReadEnum<BuiltInDecoration>(words[2], BuiltInDecoration.Unknown);
			}
			else if(decoration == Decoration.FuncParamAttr)
			{
				operands[2] = ReadEnum<FunctionParameterAttribute>(words[2], FunctionParameterAttribute.Unknown);
			}
			else if(decoration == Decoration.FPRoundingMode)
			{
				operands[2] = ReadEnum<FPRoundingMode>(words[2], FPRoundingMode.Unknown);
			}
			else if(decoration == Decoration.FPFastMathMode)
			{
				operands[2] = ReadEnum<FPFastMathMode>(words[2]).Value;
			}
			else if(decoration == Decoration.LinkageAttributes)
			{
				operands[2] = ReadString(words, 2);
				operands[3] = ReadEnum<LinkageType>(words.Last(), LinkageType.Unknown);
			}

			return operands;
		}
	}
}
