using PandorasBox.Gfx.SpirV.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandorasBox.Gfx.SpirV
{
	static class OperandInterpreter
	{
		static IDictionary<SpirVOpcodes, AbstractOperandInterpreter> operandsInterpreter = new Dictionary<SpirVOpcodes, AbstractOperandInterpreter>()
		{
			// Miscellaneous
			{ SpirVOpcodes.OpNop, new NoInterpretation() },
			{ SpirVOpcodes.OpUndef, new NoInterpretation() },

			// Debug
			{ SpirVOpcodes.OpSource, new OpSourceOperands() },
			//{ SpirVOpcodes.OpSourceExtension, new OpSourceExtensionOperands() },
			{ SpirVOpcodes.OpName, new OpNameOperands() },
			//{ SpirVOpcodes.OpMemberName, new OpMemberNameOperands() },
			//{ SpirVOpcodes.OpString, new OpStringOperands() },
			{ SpirVOpcodes.OpLine, new NoInterpretation() },

			// Annotation
			{ SpirVOpcodes.OpDecorationGroup, new NoInterpretation() },
			{ SpirVOpcodes.OpDecorate, new OpDecorateOperands() },
			//{ SpirVOpcodes.OpMemberDecorate, new OpMemberDecorateOperands() },
			{ SpirVOpcodes.OpGroupDecorate, new NoInterpretation() },
			{ SpirVOpcodes.OpGroupMemberDecorate, new NoInterpretation() },

			// Extension
			//{ SpirVOpcodes.OpExtension, new OpExtensionOperands() },
			{ SpirVOpcodes.OpExtInstImport, new OpExtInstImportOperands() },
			{ SpirVOpcodes.OpExtInst, new NoInterpretation() },

			// Mode-Setting
			{ SpirVOpcodes.OpMemoryModel, new OpMemoryModelOperands() },
			{ SpirVOpcodes.OpEntryPoint, new OpEntryPointOperands() },
			//{ SpirVOpcodes.OpExecutionMode, new OpExecutionModeOperands() },
			//{ SpirVOpcodes.OpCompileFlag, new OpCompileFlagOperands() },

			// Type-Declaration
			{ SpirVOpcodes.OpTypeVoid, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeBool, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeInt, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeFloat, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeVector, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeMatrix, new NoInterpretation() },
			//{ SpirVOpcodes.OpTypeSampler, new OpTypeSamplerOperands() },
			{ SpirVOpcodes.OpTypeFilter, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeArray, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeRuntimeArray, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeStruct, new NoInterpretation() },
			//{ SpirVOpcodes.OpTypeOpaque, new OpTypeOpaqueOperands() },
			//{ SpirVOpcodes.OpTypePointer, new OpTypePointerOperands() },
			{ SpirVOpcodes.OpTypeFunction, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeEvent, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeDeviceEvent, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeReserveId, new NoInterpretation() },
			{ SpirVOpcodes.OpTypeQueue, new NoInterpretation() },
			//{ SpirVOpcodes.OpTypePipe, new OpTypePipeOperands() },

			// Constant Creation
			{ SpirVOpcodes.OpConstantTrue, new NoInterpretation() },
			{ SpirVOpcodes.OpConstantFalse, new NoInterpretation() },
			{ SpirVOpcodes.OpConstant, new NoInterpretation() },
			{ SpirVOpcodes.OpConstantComposite, new NoInterpretation() },
			{ SpirVOpcodes.OpConstantSampler, new NoInterpretation() },
			{ SpirVOpcodes.OpConstantNullPointer, new NoInterpretation() },
			{ SpirVOpcodes.OpConstantNullObject, new NoInterpretation() },
			{ SpirVOpcodes.OpSpecConstantTrue, new NoInterpretation() },
			{ SpirVOpcodes.OpSpecConstantFalse, new NoInterpretation() },
			{ SpirVOpcodes.OpSpecConstant, new NoInterpretation() },
			{ SpirVOpcodes.OpSpecConstantComposite, new NoInterpretation() },

			// Memory
			//{ SpirVOpcodes.OpVariable, new OpVariableOperands() },
			//{ SpirVOpcodes.OpVariableArray, new OpVariableArrayOperands() },
			{ SpirVOpcodes.OpLoad, new NoInterpretation() },
			{ SpirVOpcodes.OpStore, new NoInterpretation() },
			{ SpirVOpcodes.OpCopyMemory, new NoInterpretation() },
			{ SpirVOpcodes.OpCopyMemorySized, new NoInterpretation() },
			{ SpirVOpcodes.OpAccessChain, new NoInterpretation() },
			{ SpirVOpcodes.OpInBoundsAccessChain, new NoInterpretation() },
			{ SpirVOpcodes.OpArrayLength, new NoInterpretation() },
			{ SpirVOpcodes.OpImagePointer, new NoInterpretation() },
			{ SpirVOpcodes.OpGenericPtrMemSemantics, new NoInterpretation() },

			// Function
			//{ SpirVOpcodes.OpFunction, new OpFunctionOperands() },
			{ SpirVOpcodes.OpFunctionParameter, new NoInterpretation() },
			{ SpirVOpcodes.OpFunctionEnd, new NoInterpretation() },
			{ SpirVOpcodes.OpFunctionCall, new NoInterpretation() },

			// Texture
			//{ SpirVOpcodes.OpSampler, new OpSamplerOperands() },
			//{ SpirVOpcodes.OpTextureSample, new OpTextureSampleOperands() },
			//{ SpirVOpcodes.OpTextureSampleDref, new OpTextureSampleDrefOperands() },
			//{ SpirVOpcodes.OpTextureSampleLod, new OpTextureSampleLodOperands() },
			//{ SpirVOpcodes.OpTextureSampleProj, new OpTextureSampleProjOperands() },
			//{ SpirVOpcodes.OpTextureSampleGrad, new OpTextureSampleGradOperands() },
			//{ SpirVOpcodes.OpTextureSampleOffset, new OpTextureSampleOffsetOperands() },
			//{ SpirVOpcodes.OpTextureSampleProjLod, new OpTextureSampleProjLodOperands() },
			//{ SpirVOpcodes.OpTextureSampleProjGrad, new OpTextureSampleProjGradOperands() },
			//{ SpirVOpcodes.OpTextureSampleLodOffset, new OpTextureSampleLodOffsetOperands() },
			//{ SpirVOpcodes.OpTextureSampleProjOffset, new OpTextureSampleProjOffsetOperands() },
			//{ SpirVOpcodes.OpTextureSampleGradOffset, new OpTextureSampleGradOffsetOperands() },
			//{ SpirVOpcodes.OpTextureSampleProjLodOffset, new OpTextureSampleProjLodOffsetOperands() },
			//{ SpirVOpcodes.OpTextureSampleProjGradOffset, new OpTextureSampleProjGradOffsetOperands() },
			//{ SpirVOpcodes.OpTextureFetchTexelLod, new OpTextureFetchTexelLodOperands() },
			//{ SpirVOpcodes.OpTextureFetchTexelOffset, new OpTextureFetchTexelOffsetOperands() },
			//{ SpirVOpcodes.OpTextureFetchSample, new OpTextureFetchSampleOperands() },
			//{ SpirVOpcodes.OpTextureFetchTexel, new OpTextureFetchTexelOperands() },
			//{ SpirVOpcodes.OpTextureGather, new OpTextureGatherOperands() },
			//{ SpirVOpcodes.OpTextureGatherOffset, new OpTextureGatherOffsetOperands() },
			//{ SpirVOpcodes.OpTextureGatherOffsets, new OpTextureGatherOffsetsOperands() },
			//{ SpirVOpcodes.OpTextureQuerySizeLod, new OpTextureQuerySizeLodOperands() },
			//{ SpirVOpcodes.OpTextureQuerySize, new OpTextureQuerySizeOperands() },
			//{ SpirVOpcodes.OpTextureQueryLod, new OpTextureQueryLodOperands() },
			//{ SpirVOpcodes.OpTextureQueryLevels, new OpTextureQueryLevelsOperands() },
			//{ SpirVOpcodes.OpTextureQuerySamples, new OpTextureQuerySamplesOperands() },

			// Conversion
			//{ SpirVOpcodes.OpConvertFToU, new OpConvertFToUOperands() },
			//{ SpirVOpcodes.OpConvertFToS, new OpConvertFToSOperands() },
			//{ SpirVOpcodes.OpConvertSToF, new OpConvertSToFOperands() },
			//{ SpirVOpcodes.OpConvertUToF, new OpConvertUToFOperands() },
			//{ SpirVOpcodes.OpUConvert, new OpUConvertOperands() },
			//{ SpirVOpcodes.OpSConvert, new OpSConvertOperands() },
			//{ SpirVOpcodes.OpFConvert, new OpFConvertOperands() },
			//{ SpirVOpcodes.OpConvertPtrToU, new OpConvertPtrToUOperands() },
			//{ SpirVOpcodes.OpConvertUToPtr, new OpConvertUToPtrOperands() },
			//{ SpirVOpcodes.OpPtrCastToGeneric, new OpPtrCastToGenericOperands() },
			//{ SpirVOpcodes.OpGenericCastToPtr, new OpGenericCastToPtrOperands() },
			//{ SpirVOpcodes.OpBitcast, new OpBitcastOperands() },
			//{ SpirVOpcodes.OpGenericCastToPtrExplicit, new OpGenericCastToPtrExplicitOperands() },
			//{ SpirVOpcodes.OpSatConvertSToU, new OpSatConvertSToUOperands() },
			//{ SpirVOpcodes.OpSatConvertUToS, new OpSatConvertUToSOperands() },

			// Composite
			//{ SpirVOpcodes.OpVectorExtractDynamic, new OpVectorExtractDynamicOperands() },
			//{ SpirVOpcodes.OpVectorInsertDynamic, new OpVectorInsertDynamicOperands() },
			//{ SpirVOpcodes.OpVectorShuffle, new OpVectorShuffleOperands() },
			//{ SpirVOpcodes.OpCompositeConstruct, new OpCompositeConstructOperands() },
			//{ SpirVOpcodes.OpCompositeExtract, new OpCompositeExtractOperands() },
			//{ SpirVOpcodes.OpCompositeInsert, new OpCompositeInsertOperands() },
			//{ SpirVOpcodes.OpCopyObject, new OpCopyObjectOperands() },
			//{ SpirVOpcodes.OpTranspose, new OpTransposeOperands() },

			// Arithmetic
			//{ SpirVOpcodes.OpSNegate, new OpSNegateOperands() },
			//{ SpirVOpcodes.OpFNegate, new OpFNegateOperands() },
			//{ SpirVOpcodes.OpNot, new OpNotOperands() },
			//{ SpirVOpcodes.OpIAdd, new OpIAddOperands() },
			//{ SpirVOpcodes.OpFAdd, new OpFAddOperands() },
			//{ SpirVOpcodes.OpISub, new OpISubOperands() },
			//{ SpirVOpcodes.OpFSub, new OpFSubOperands() },
			//{ SpirVOpcodes.OpIMul, new OpIMulOperands() },
			//{ SpirVOpcodes.OpFMul, new OpFMulOperands() },
			//{ SpirVOpcodes.OpUDiv, new OpUDivOperands() },
			//{ SpirVOpcodes.OpSDiv, new OpSDivOperands() },
			//{ SpirVOpcodes.OpFDiv, new OpFDivOperands() },
			//{ SpirVOpcodes.OpUMod, new OpUModOperands() },
			//{ SpirVOpcodes.OpSRem, new OpSRemOperands() },
			//{ SpirVOpcodes.OpSMod, new OpSModOperands() },
			//{ SpirVOpcodes.OpFRem, new OpFRemOperands() },
			//{ SpirVOpcodes.OpFMod, new OpFModOperands() },
			//{ SpirVOpcodes.OpVectorTimesScalar, new OpVectorTimesScalarOperands() },
			//{ SpirVOpcodes.OpMatrixTimesScalar, new OpMatrixTimesScalarOperands() },
			//{ SpirVOpcodes.OpVectorTimesMatrix, new OpVectorTimesMatrixOperands() },
			//{ SpirVOpcodes.OpMatrixTimesVector, new OpMatrixTimesVectorOperands() },
			//{ SpirVOpcodes.OpMatrixTimesMatrix, new OpMatrixTimesMatrixOperands() },
			//{ SpirVOpcodes.OpOuterProduct, new OpOuterProductOperands() },
			//{ SpirVOpcodes.OpDot, new OpDotOperands() },
			//{ SpirVOpcodes.OpShiftRightLogical, new OpShiftRightLogicalOperands() },
			//{ SpirVOpcodes.OpShiftRightArithmetic, new OpShiftRightArithmeticOperands() },
			//{ SpirVOpcodes.OpShiftLeftLogical, new OpShiftLeftLogicalOperands() },
			//{ SpirVOpcodes.OpBitwiseOr, new OpBitwiseOrOperands() },
			//{ SpirVOpcodes.OpBitwiseXor, new OpBitwiseXorOperands() },
			//{ SpirVOpcodes.OpBitwiseAnd, new OpBitwiseAndOperands() },

			//Relational and Logical
			//{ SpirVOpcodes.OpAny, new OpAnyOperands() },
			//{ SpirVOpcodes.OpAll, new OpAllOperands() },
			//{ SpirVOpcodes.OpIsNan, new OpIsNanOperands() },
			//{ SpirVOpcodes.OpIsInf, new OpIsInfOperands() },
			//{ SpirVOpcodes.OpIsFinite, new OpIsFiniteOperands() },
			//{ SpirVOpcodes.OpIsNormal, new OpIsNormalOperands() },
			//{ SpirVOpcodes.OpSignBitSet, new OpSignBitSetOperands() },
			//{ SpirVOpcodes.OpLessOrGreater, new OpLessOrGreaterOperands() },
			//{ SpirVOpcodes.OpOrdered, new OpOrderedOperands() },
			//{ SpirVOpcodes.OpUnordered, new OpUnorderedOperands() },
			//{ SpirVOpcodes.OpLogicalOr, new OpLogicalOrOperands() },
			//{ SpirVOpcodes.OpLogicalXor, new OpLogicalXorOperands() },
			//{ SpirVOpcodes.OpLogicalAnd, new OpLogicalAndOperands() },
			//{ SpirVOpcodes.OpSelect, new OpSelectOperands() },
			//{ SpirVOpcodes.OpIEqual, new OpIEqualOperands() },
			//{ SpirVOpcodes.OpFOrdEqual, new OpFOrdEqualOperands() },
			//{ SpirVOpcodes.OpFUnordEqual, new OpFUnordEqualOperands() },
			//{ SpirVOpcodes.OpINotEqual, new OpINotEqualOperands() },
			//{ SpirVOpcodes.OpFOrdNotEqual, new OpFOrdNotEqualOperands() },
			//{ SpirVOpcodes.OpFUnordNotEqual, new OpFUnordNotEqualOperands() },
			//{ SpirVOpcodes.OpULessThan, new OpULessThanOperands() },
			//{ SpirVOpcodes.OpSLessThan, new OpSLessThanOperands() },
			//{ SpirVOpcodes.OpFOrdLessThan, new OpFOrdLessThanOperands() },
			//{ SpirVOpcodes.OpFUnordLessThan, new OpFUnordLessThanOperands() },
			//{ SpirVOpcodes.OpUGreaterThan, new OpUGreaterThanOperands() },
			//{ SpirVOpcodes.OpSGreaterThan, new OpSGreaterThanOperands() },
			//{ SpirVOpcodes.OpFOrdGreaterThan, new OpFOrdGreaterThanOperands() },
			//{ SpirVOpcodes.OpFUnordGreaterThan, new OpFUnordGreaterThanOperands() },
			//{ SpirVOpcodes.OpULessThanEqual, new OpULessThanEqualOperands() },
			//{ SpirVOpcodes.OpSLessThanEqual, new OpSLessThanEqualOperands() },
			//{ SpirVOpcodes.OpFOrdLessThanEqual, new OpFOrdLessThanEqualOperands() },
			//{ SpirVOpcodes.OpFUnordLessThanEqual, new OpFUnordLessThanEqualOperands() },
			//{ SpirVOpcodes.OpUGreaterThanEqual, new OpUGreaterThanEqualOperands() },
			//{ SpirVOpcodes.OpSGreaterThanEqual, new OpSGreaterThanEqualOperands() },
			//{ SpirVOpcodes.OpFOrdGreaterThanEqual, new OpFOrdGreaterThanEqualOperands() },
			//{ SpirVOpcodes.OpFUnordGreaterThanEqual, new OpFUnordGreaterThanEqualOperands() },

			// Derivative
			//{ SpirVOpcodes.OpDPdx, new OpDPdxOperands() },
			//{ SpirVOpcodes.OpDPdy, new OpDPdyOperands() },
			//{ SpirVOpcodes.OpFwidth, new OpFwidthOperands() },
			//{ SpirVOpcodes.OpDPdxFine, new OpDPdxFineOperands() },
			//{ SpirVOpcodes.OpDPdyFine, new OpDPdyFineOperands() },
			//{ SpirVOpcodes.OpFwidthFine, new OpFwidthFineOperands() },
			//{ SpirVOpcodes.OpDPdxCoarse, new OpDPdxCoarseOperands() },
			//{ SpirVOpcodes.OpDPdyCoarse, new OpDPdyCoarseOperands() },
			//{ SpirVOpcodes.OpFwidthCoarse, new OpFwidthCoarseOperands() },

			// Flow Control
			//{ SpirVOpcodes.OpPhi, new OpPhiOperands() },
			//{ SpirVOpcodes.OpLoopMerge, new OpLoopMergeOperands() },
			//{ SpirVOpcodes.OpSelectionMerge, new OpSelectionMergeOperands() },
			//{ SpirVOpcodes.OpLabel, new OpLabelOperands() },
			//{ SpirVOpcodes.OpBranch, new OpBranchOperands() },
			//{ SpirVOpcodes.OpBranchConditional, new OpBranchConditionalOperands() },
			//{ SpirVOpcodes.OpSwitch, new OpSwitchOperands() },
			//{ SpirVOpcodes.OpKill, new OpKillOperands() },
			//{ SpirVOpcodes.OpReturn, new OpReturnOperands() },
			//{ SpirVOpcodes.OpReturnValue, new OpReturnValueOperands() },
			//{ SpirVOpcodes.OpUnreachable, new OpUnreachableOperands() },
			//{ SpirVOpcodes.OpLifetimeStart, new OpLifetimeStartOperands() },
			//{ SpirVOpcodes.OpLifetimeStop, new OpLifetimeStopOperands() },

			// Atomic
			//{ SpirVOpcodes.OpAtomicInit, new OpAtomicInitOperands() },
			//{ SpirVOpcodes.OpAtomicLoad, new OpAtomicLoadOperands() },
			//{ SpirVOpcodes.OpAtomicStore, new OpAtomicStoreOperands() },
			//{ SpirVOpcodes.OpAtomicExchange, new OpAtomicExchangeOperands() },
			//{ SpirVOpcodes.OpAtomicCompareExchange, new OpAtomicCompareExchangeOperands() },
			//{ SpirVOpcodes.OpAtomicCompareExchangeWeak, new OpAtomicCompareExchangeWeakOperands() },
			//{ SpirVOpcodes.OpAtomicIIncrement, new OpAtomicIIncrementOperands() },
			//{ SpirVOpcodes.OpAtomicIDecrement, new OpAtomicIDecrementOperands() },
			//{ SpirVOpcodes.OpAtomicIAdd, new OpAtomicIAddOperands() },
			//{ SpirVOpcodes.OpAtomicISub, new OpAtomicISubOperands() },
			//{ SpirVOpcodes.OpAtomicUMin, new OpAtomicUMinOperands() },
			//{ SpirVOpcodes.OpAtomicUMax, new OpAtomicUMaxOperands() },
			//{ SpirVOpcodes.OpAtomicAnd, new OpAtomicAndOperands() },
			//{ SpirVOpcodes.OpAtomicOr, new OpAtomicOrOperands() },
			//{ SpirVOpcodes.OpAtomicXor, new OpAtomicXorOperands() },
			//{ SpirVOpcodes.OpAtomicIMin, new OpAtomicIMinOperands() },
			//{ SpirVOpcodes.OpAtomicIMax, new OpAtomicIMaxOperands() },

			// Primitive
			//{ SpirVOpcodes.OpEmitVertex, new OpEmitVertexOperands() },
			//{ SpirVOpcodes.OpEndPrimitive, new OpEndPrimitiveOperands() },
			//{ SpirVOpcodes.OpEmitStreamVertex, new OpEmitStreamVertexOperands() },
			//{ SpirVOpcodes.OpEndStreamPrimitive, new OpEndStreamPrimitiveOperands() },

			// Barrier
			//{ SpirVOpcodes.OpControlBarrier, new OpControlBarrierOperands() },
			//{ SpirVOpcodes.OpMemoryBarrier, new OpMemoryBarrierOperands() },

			// Group
			//{ SpirVOpcodes.OpAsyncGroupCopy, new OpAsyncGroupCopyOperands() },
			//{ SpirVOpcodes.OpWaitGroupEvents, new OpWaitGroupEventsOperands() },
			//{ SpirVOpcodes.OpGroupAll, new OpGroupAllOperands() },
			//{ SpirVOpcodes.OpGroupAny, new OpGroupAnyOperands() },
			//{ SpirVOpcodes.OpGroupBroadcast, new OpGroupBroadcastOperands() },
			//{ SpirVOpcodes.OpGroupIAdd, new OpGroupIAddOperands() },
			//{ SpirVOpcodes.OpGroupFAdd, new OpGroupFAddOperands() },
			//{ SpirVOpcodes.OpGroupFMin, new OpGroupFMinOperands() },
			//{ SpirVOpcodes.OpGroupUMin, new OpGroupUMinOperands() },
			//{ SpirVOpcodes.OpGroupSMin, new OpGroupSMinOperands() },
			//{ SpirVOpcodes.OpGroupFMax, new OpGroupFMaxOperands() },
			//{ SpirVOpcodes.OpGroupUMax, new OpGroupUMaxOperands() },
			//{ SpirVOpcodes.OpGroupSMax, new OpGroupSMaxOperands() },

			// Device-Side Enqueue
			//{ SpirVOpcodes.OpEnqueueMarker, new OpEnqueueMarkerOperands() },
			//{ SpirVOpcodes.OpEnqueueKernel, new OpEnqueueKernelOperands() },
			//{ SpirVOpcodes.OpGetKernelNDrangeSubGroupCount, new OpGetKernelNDrangeSubGroupCountOperands() },
			//{ SpirVOpcodes.OpGetKernelNDrangeMaxSubGroupSize, new OpGetKernelNDrangeMaxSubGroupSizeOperands() },
			//{ SpirVOpcodes.OpGetKernelWorkGroupSize, new OpGetKernelWorkGroupSizeOperands() },
			//{ SpirVOpcodes.OpGetKernelPreferredWorkGroupSizeMultiple, new OpGetKernelPreferredWorkGroupSizeMultipleOperands() },
			//{ SpirVOpcodes.OpRetainEvent, new OpRetainEventOperands() },
			//{ SpirVOpcodes.OpReleaseEvent, new OpReleaseEventOperands() },
			//{ SpirVOpcodes.OpCreateUserEvent, new OpCreateUserEventOperands() },
			//{ SpirVOpcodes.OpIsValidEvent, new OpIsValidEventOperands() },
			//{ SpirVOpcodes.OpSetUserEventStatus, new OpSetUserEventStatusOperands() },
			//{ SpirVOpcodes.OpCaptureEventProfilingInfo, new OpCaptureEventProfilingInfoOperands() },
			//{ SpirVOpcodes.OpGetDefaultQueue, new OpGetDefaultQueueOperands() },
			//{ SpirVOpcodes.OpBuildNDRange, new OpBuildNDRangeOperands() },

			// Pipe
			//{ SpirVOpcodes.OpReadPipe, new OpReadPipeOperands() },
			//{ SpirVOpcodes.OpWritePipe, new OpWritePipeOperands() },
			//{ SpirVOpcodes.OpReservedReadPipe, new OpReservedReadPipeOperands() },
			//{ SpirVOpcodes.OpReservedWritePipe, new OpReservedWritePipeOperands() },
			//{ SpirVOpcodes.OpReserveReadPipePackets, new OpReserveReadPipePacketsOperands() },
			//{ SpirVOpcodes.OpReserveWritePipePackets, new OpReserveWritePipePacketsOperands() },
			//{ SpirVOpcodes.OpCommitReadPipe, new OpCommitReadPipeOperands() },
			//{ SpirVOpcodes.OpCommitWritePipe, new OpCommitWritePipeOperands() },
			//{ SpirVOpcodes.OpIsValidReserveId, new OpIsValidReserveIdOperands() },
			//{ SpirVOpcodes.OpGetNumPipePackets, new OpGetNumPipePacketsOperands() },
			//{ SpirVOpcodes.OpGetMaxPipePackets, new OpGetMaxPipePacketsOperands() },
			//{ SpirVOpcodes.OpGroupReserveReadPipePackets, new OpGroupReserveReadPipePacketsOperands() },
			//{ SpirVOpcodes.OpGroupReserveWritePipePackets, new OpGroupReserveWritePipePacketsOperands() },
			//{ SpirVOpcodes.OpGroupCommitReadPipe, new OpGroupCommitReadPipeOperands() },
			//{ SpirVOpcodes.OpGroupCommitWritePipe, new OpGroupCommitWritePipeOperands() }
		};

		public static Object[] GetOperands(SpirVOpcodes opcode, int[] words)
		{
			Object[] operands = null;
			AbstractOperandInterpreter interpreter;
            if (operandsInterpreter.TryGetValue(opcode, out interpreter))
			{
				return interpreter.Interpret(words);
			}
			else
			{
				operands = Array.ConvertAll<int, Object>(words, x => x);
			}
			return operands;
		}

		private static object readString(int[] words, int offset)
		{
			StringBuilder builder = new StringBuilder(4 * (words.Length - offset));
			for (int i = offset; i < words.Length; i++)
			{
				int j = 0;
				char letter;
				do
				{
					letter = (char)((words[i] >> (j * 8)) & 0xFF);
					if (letter == '\0') break;
					builder.Append(letter);
					j++;
				} while (letter != 0 && j < 4);
			}
			return builder.ToString();
		}
	}
}
