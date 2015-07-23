using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox2.OS.Win32.PInvoke
{
	[Flags]
	public enum PFDFlags : uint
	{
		PFD_DOUBLEBUFFER = 0x00000001,
		PFD_STEREO = 0x00000002,
		PFD_DRAW_TO_WINDOW = 0x00000004,
		PFD_DRAW_TO_BITMAP = 0x00000008,
		PFD_SUPPORT_GDI = 0x00000010,
		PFD_SUPPORT_OPENGL = 0x00000020,
		PFD_GENERIC_FORMAT = 0x00000040,
		PFD_NEED_PALETTE = 0x00000080,
		PFD_NEED_SYSTEM_PALETTE = 0x00000100,
		PFD_SWAP_EXCHANGE = 0x00000200,
		PFD_SWAP_COPY = 0x00000400,
		PFD_SWAP_LAYER_BUFFERS = 0x00000800,
		PFD_GENERIC_ACCELERATED = 0x00001000,
		PFD_SUPPORT_DIRECTDRAW = 0x00002000,
		PFD_DIRECT3D_ACCELERATED = 0x00004000,
		PFD_SUPPORT_COMPOSITION = 0x00008000
	}

	public enum PFDPixelType : byte
	{
		PFD_TYPE_RGBA = 0,
		PFD_TYPE_COLORINDEX = 1
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct PixelFormatDescriptor
	{
		/// <summary>
		/// Specifies the size of this data structure. This value should be set to sizeof(PIXELFORMATDESCRIPTOR).
		/// </summary>
		public ushort nSize;

		/// <summary>
		/// Specifies the version of this data structure. This value should be set to 1.
		/// </summary>
		public ushort nVersion;

		/// <summary>
		/// A set of bit flags that specify properties of the pixel buffer
		/// </summary>
		public PFDFlags dwFlags;

		/// <summary>
		/// Specifies the type of pixel data
		/// </summary>
		public PFDPixelType iPixelType;

		/// <summary>
		/// Specifies the number of color bitplanes in each color buffer. For RGBA pixel types, it is the size of
		/// the color buffer, excluding the alpha bitplanes. For color-index pixels, it is the size of the color-index buffer
		/// </summary>
		public byte cColorBits;

		/// <summary>
		/// Specifies the number of red bitplanes in each RGBA color buffer
		/// </summary>
		public byte cRedBits;

		/// <summary>
		/// Specifies the shift count for red bitplanes in each RGBA color buffer
		/// </summary>
		public byte cRedShift;

		/// <summary>
		/// Specifies the number of green bitplanes in each RGBA color buffer
		/// </summary>
		public byte cGreenBits;

		/// <summary>
		/// Specifies the shift count for green bitplanes in each RGBA color buffer
		/// </summary>
		public byte cGreenShift;

		/// <summary>
		/// Specifies the shift count for green bitplanes in each RGBA color buffer
		/// </summary>
		public byte cBlueBits;

		/// <summary>
		/// Specifies the shift count for blue bitplanes in each RGBA color buffer
		/// </summary>
		public byte cBlueShift;

		/// <summary>
		/// Specifies the number of alpha bitplanes in each RGBA color buffer. 
		/// Alpha bitplanes are not supported
		/// </summary>
		public byte cAlphaBits;

		/// <summary>
		/// Specifies the shift count for alpha bitplanes in each RGBA color buffer. 
		/// Alpha bitplanes are not supported
		/// </summary>
		public byte cAlphaShift;

		/// <summary>
		/// Specifies the total number of bitplanes in the accumulation buffer
		/// </summary>
		public byte cAccumBits;

		/// <summary>
		/// Specifies the number of red bitplanes in the accumulation buffer
		/// </summary>
		public byte cAccumRedBits;

		/// <summary>
		/// Specifies the number of green bitplanes in the accumulation buffer
		/// </summary>
		public byte cAccumGreenBits;

		/// <summary>
		/// Specifies the number of blue bitplanes in the accumulation buffer
		/// </summary>
		public byte cAccumBlueBits;

		/// <summary>
		/// Specifies the number of alpha bitplanes in the accumulation buffer
		/// </summary>
		public byte cAccumAlphaBits;

		/// <summary>
		/// Specifies the depth of the depth (z-axis) buffer
		/// </summary>
		public byte cDepthBits;

		/// <summary>
		/// Specifies the depth of the stencil buffer
		/// </summary>
		public byte cStencilBits;

		/// <summary>
		/// Specifies the number of auxiliary buffers. Auxiliary buffers are not supported
		/// </summary>
		public byte cAuxBuffers;

		/// <summary>
		/// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used
		/// </summary>
		public byte iLayerType;

		/// <summary>
		/// Specifies the number of overlay and underlay planes. Bits 0 through 3 specify up to 15 
		/// overlay planes and bits 4 through 7 specify up to 15 underlay planes
		/// </summary>
		public byte bReserved;

		/// <summary>
		/// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used
		/// </summary>
		public uint dwLayerMask;

		/// <summary>
		/// Specifies the transparent color or index of an underlay plane. When the pixel type is RGBA,
		/// dwVisibleMask is a transparent RGB color value. When the pixel type is color index, it is a
		/// transparent index value
		/// </summary>
		public uint dwVisibleMask;

		/// <summary>
		/// Ignored. Earlier implementations of OpenGL used this member, but it is no longer used
		/// </summary>
		public uint dwDamageMask;

		public static PixelFormatDescriptor DefaultFormat()
		{
			PixelFormatDescriptor pfd = default(PixelFormatDescriptor);
			pfd.nSize = (ushort)Marshal.SizeOf(typeof(PixelFormatDescriptor));
			pfd.nVersion = 1;
			pfd.dwFlags = PFDFlags.PFD_DRAW_TO_WINDOW | PFDFlags.PFD_SUPPORT_OPENGL | PFDFlags.PFD_DOUBLEBUFFER;
			pfd.iPixelType = PFDPixelType.PFD_TYPE_RGBA;
			pfd.cColorBits = 32;
			pfd.cDepthBits = 24;
			pfd.cStencilBits = 8;
			pfd.iLayerType = 0; // PFD_MAIN_PLANE
			return pfd;
		}
	}
}
