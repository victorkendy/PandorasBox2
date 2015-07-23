using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.OpenGL.PInvoke
{
	public enum GLStringNames
	{
		GL_VENDOR = 0x1F00,
		GL_RENDERER = 0x1F01,
		GL_VERSION = 0x1F02,
		GL_EXTENSIONS = 0x1F03,
	}

	public enum GLError
	{
		GL_NO_ERROR = 0,
		GL_INVALID_ENUM = 0x0500,
		GL_INVALID_VALUE = 0x0501,
		GL_INVALID_OPERATION = 0x0502,
		GL_STACK_OVERFLOW = 0x0503,
		GL_STACK_UNDERFLOW = 0x0504,
		GL_OUT_OF_MEMORY = 0x0505,
		GL_TABLE_TOO_LARGE = 0x8031,
	}

	[Flags]
	public enum GLClearBit
	{
		GL_COLOR_BUFFER_BIT   = 0x00004000,
		GL_STENCIL_BUFFER_BIT = 0x00000400,
		GL_DEPTH_BUFFER_BIT   = 0x00000100,
	}
	public enum GLPrimitiveType
	{
		GL_TRIANGLES = 0x0004,
	}

	public enum ClientState
	{
		GL_VERTEX_ARRAY = 0x8074,
		GL_COLOR_ARRAY = 0x8076,
		GL_NORMAL_ARRAY = 0x8075,
	}

	public enum DataType
	{
		GL_BYTE = 0x1400,
		GL_UNSIGNED_BYTE = 0x1401,
		GL_SHORT = 0x1402,
		GL_UNSIGNED_SHORT = 0x1403,
		GL_FLOAT = 0x1406,
		GL_FIXED = 0x140C,
	}
	// only 1.1 stuff here...
	// The remaining methods should be dynamically bound with wglGetProcAddress
	public static class GL
	{
		#region textures

		#endregion
		[DllImport("OpenGL32.dll", EntryPoint = "glGetString")]
		public static extern IntPtr GetString(GLStringNames name);

		[DllImport("opengl32.dll", EntryPoint = "glClearColor")]
		public static extern void ClearColor(float red, float green, float blue, float alpha);

		[DllImport("opengl32.dll", EntryPoint = "glClear")]
		public static extern void Clear(GLClearBit mask);

		[DllImport("opengl32.dll", EntryPoint = "glGetError")]
		public static extern uint GetError();

		[DllImport("opengl32.dll", EntryPoint = "glFlush")]
		public static extern void Flush();

		[DllImport("opengl32.dll", EntryPoint = "glEnableClientState")]
		public static extern void EnableClientState(ClientState state);

		[DllImport("opengl32.dll", EntryPoint = "glDisableClientState")]
		public static extern void DisableClientState(ClientState state);

		[DllImport("opengl32.dll", EntryPoint="glDrawElements")]
		public static extern void DrawElements(GLPrimitiveType primitive, int count, uint type, int[] indices);

		[DllImport("opengl32.dll", EntryPoint = "glDrawArrays")]
		public static extern void DrawArrays(GLPrimitiveType primitive, int first, int count);

		[DllImport("opengl32.dll", EntryPoint = "glVertexPointer")]
		public static extern void VertexPointer(int size, DataType type, int stride, IntPtr pointer);
		

		[DllImport("opengl32.dll", EntryPoint="glColor4f")]
		public static extern void Color(float red, float green, float blue, float alpha);
		[DllImport("opengl32.dll", EntryPoint = "glVertex4f")]
		public static extern void Vertex(float x, float y, float z, float w);
		[DllImport("opengl32.dll", EntryPoint = "glBegin")]
		public static extern void Begin(GLPrimitiveType primitive);
		[DllImport("opengl32.dll", EntryPoint = "glEnd")]
		public static extern void End();
	}
}
