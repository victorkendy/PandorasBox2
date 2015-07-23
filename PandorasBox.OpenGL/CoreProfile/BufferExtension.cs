using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.OpenGL.PInvoke;

namespace PandorasBox.OpenGL
{
	public enum BufferBindTarget
	{
		GL_ARRAY_BUFFER = 0x8892,
		GL_ELEMENT_ARRAY_BUFFER = 0x8893,
		GL_PIXEL_PACK_BUFFER = 0x88EB,
		GL_PIXEL_UNPACK_BUFFER = 0x88EC,
		GL_COPY_READ_BUFFER = 0x8F36,
		GL_COPY_WRITE_BUFFER = 0x8F37,
		GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E,
		GL_UNIFORM_BUFFER = 0x8A11,
	}

	public enum BufferUsage
	{
		GL_STREAM_DRAW = 0x88E0,
		GL_STREAM_READ = 0x88E1,
		GL_STREAM_COPY = 0x88E2,
		GL_STATIC_DRAW = 0x88E4,
		GL_STATIC_READ = 0x88E5,
		GL_STATIC_COPY = 0x88E6,
		GL_DYNAMIC_DRAW = 0x88E8,
		GL_DYNAMIC_READ = 0x88E9,
		GL_DYNAMIC_COPY = 0x88EA,
	}

	public class BufferExtension
	{
		public delegate void GenBuffersDelegate(int n, uint[] names);
		public delegate void DeleteBuffersDelegate(int n, uint[] names);
		public delegate void BindBufferDelegate(BufferBindTarget target, uint buffer);
		public delegate void BufferDataDelegate(BufferBindTarget target, int size, IntPtr data, BufferUsage usage);
		public delegate void BufferSubDataDelegate(BufferBindTarget target, int offset, int size, IntPtr data);
		public delegate IntPtr MapBufferDelegate();

		public static GenBuffersDelegate GenBuffers { get; private set; }
		public static DeleteBuffersDelegate DeleteBuffers { get; private set; }
		public static BindBufferDelegate BindBuffer { get; private set; }
		public static BufferDataDelegate BufferData { get; private set; }
		public static BufferSubDataDelegate BufferSubData { get; private set; }

		internal static void Initialize(AbstractGLGraphicDriver driver)
		{
			GenBuffers = (GenBuffersDelegate) Marshal.GetDelegateForFunctionPointer(driver.GetGLEntryPoint("glGenBuffers"), typeof(GenBuffersDelegate));
			DeleteBuffers = (DeleteBuffersDelegate) Marshal.GetDelegateForFunctionPointer(driver.GetGLEntryPoint("glDeleteBuffers"), typeof(DeleteBuffersDelegate));
			BindBuffer = (BindBufferDelegate) Marshal.GetDelegateForFunctionPointer(driver.GetGLEntryPoint("glBindBuffer"), typeof(BindBufferDelegate));
			BufferData = (BufferDataDelegate) Marshal.GetDelegateForFunctionPointer(driver.GetGLEntryPoint("glBufferData"), typeof(BufferDataDelegate));
			BufferSubData = (BufferSubDataDelegate) Marshal.GetDelegateForFunctionPointer(driver.GetGLEntryPoint("glBufferSubData"), typeof(BufferSubDataDelegate));
		}
	}
}
