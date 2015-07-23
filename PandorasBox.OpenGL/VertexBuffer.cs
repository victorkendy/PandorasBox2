using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandorasBox.OpenGL.PInvoke;

namespace PandorasBox.OpenGL
{
	class VertexBuffer
	{
		private uint glName;

		public VertexBuffer(uint name)
		{
			this.glName = name;
		}

		public void Draw()
		{
			BufferExtension.BindBuffer(BufferBindTarget.GL_ARRAY_BUFFER, glName);
			GL.EnableClientState(ClientState.GL_VERTEX_ARRAY);
			GL.VertexPointer(3, DataType.GL_FLOAT, 0, IntPtr.Zero);
			GL.DrawArrays(GLPrimitiveType.GL_TRIANGLES, 0, 3);
			GL.DisableClientState(ClientState.GL_VERTEX_ARRAY);
			BufferExtension.BindBuffer(BufferBindTarget.GL_ARRAY_BUFFER, 0);
		}
	}
}
