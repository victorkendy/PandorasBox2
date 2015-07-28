using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	public enum SpirVOpcodes
	{
		OpUnknown =			-1, // Don't know the instruction. (Out of the spec)

		// Debug
		OpSource =			1,
		OpName =			54,

		OpExtInstImport =	4,

		// Mode-Setting
		OpMemoryModel =		5,
		OpEntryPoint =		6,

		// Type-Declaration
		OpTypeVoid =		8,
		OpTypeFloat =		11,
		OpTypeVector =		12,
		OpTypePointer =		20,
		OpTypeFunction =	21,

		// Constant Creation
		OpConstant =		29,

		// Function
		OpFunction =		40,
		OpFunctionEnd =		42,

		// Flow Control
		OpLabel =			208,
		OpBranch =			209,
		OpReturn =			213,

		// Memory
		OpVariable =		38,
		OpLoad =			46,
		OpStore =			47,

		// Annotation
		OpDecorate =		50,

		// Composite
		OpCompositeConstruct=61,
		OpCompositeExtract =62,
	}
}
