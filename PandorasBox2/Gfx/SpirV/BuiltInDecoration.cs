using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Gfx.SpirV
{
	public enum BuiltInDecoration
	{
		Position = 0,
		PointSize = 1,
		ClipVertex = 2,
		ClipDistance = 3,
		CullDistance = 4,
		VertexId = 5,
		InstanceId = 6,
		PrimitiveId = 7,
		InvocationId = 8,
		Layer = 9,
		ViewportIndex = 10,
		TessLevelOuter = 11,
		TessLevelInner = 12,
		TessCoord = 13,
		PatchVertices = 14,
		FragCoord = 15,
		PointCoord = 16,
		FrontFacing = 17,
		SampleId = 18,
		SamplePosition = 19,
		SampleMask = 20,
		FragColor = 21,
		FragDepth = 22,
		HelperInvocation = 23,
		NumWorkgroups = 24,
		WorkgroupSize = 25,
		WorkgroupId = 26,
		LocalInvocationId = 27,
		GlobalInvocationId = 28,
		LocalInvocationIndex = 29,
		WorkDim = 30,
		GlobalSize = 31,
		EnqueuedWorkgroupSize = 32,
		GlobalOffset = 33,
		GlobalLinearId = 34,
		WorkgroupLinearId = 35,
		SubgroupSize = 36,
		SubgroupMaxSize = 37,
		NumSubgroups = 38,
		NumEnqueuedSubgroups = 39,
		SubgroupId = 40,
		SubgroupLocalInvocationId = 41,
		Unknown = -1,
	}
}
