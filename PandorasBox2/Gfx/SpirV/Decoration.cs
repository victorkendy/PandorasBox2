using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	public enum Decoration
	{
		PrecisionLow = 0,
		PrecisionMedium = 1,
		PrecisionHigh = 2,
		Block = 3,
		BufferBlock = 4,
		RowMajor = 5,
		ColMajor = 6,
		GLSLShared = 7,
		GLSLStd140 = 8,
		GLSLStd430 = 9,
		GLSLPacked = 10,
		Smooth = 11,
		Noperspective = 12,
		Flat = 13,
		Patch = 14,
		Centroid = 15,
		Sample = 16,
		Invariant = 17,
		Restrict = 18,
		Aliased = 19,
		Volatile = 20,
		Constant = 21,
		Coherent = 22,
		Nonwritable = 23,
		Nonreadable = 24,
		Uniform = 25,
		NoStaticUse = 26,
		CPacked = 27,
		SaturatedConversion = 28,
		Stream = 29,
		Location = 30,
		Component = 31,
		Index = 32,
		Binding = 33,
		DescriptorSet = 34,
		Offset = 35,
		Alignment = 36,
		XfbBuffer = 37,
		Stride = 38,
		BuiltIn = 39,
		FuncParamAttr = 40,
		FPRoundingMode = 41,
		FPFastMathMode = 42,
		LinkageAttributes = 43,
		SpecId = 44,
	}
}
