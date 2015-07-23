using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.OpenGL
{
	public class GLResourceFactory
	{
		internal VertexBuffer CreateVertexBuffer()
		{
			GCHandle handle = default(GCHandle);
			try
			{
				uint[] bufferNames = new uint[1];
				BufferExtension.GenBuffers(1, bufferNames);
				BufferExtension.BindBuffer(BufferBindTarget.GL_ARRAY_BUFFER, bufferNames[0]);
				float[] data = {-1.0f, 0.0f, -0.5f, 
							0.0f, 1.0f, -0.5f, 
							1.0f, 0.0f, -0.5f };
				handle = GCHandle.Alloc(data, GCHandleType.Pinned);
				IntPtr dataPtr = handle.AddrOfPinnedObject();
				BufferExtension.BufferData(BufferBindTarget.GL_ARRAY_BUFFER, 9 * sizeof(float), dataPtr, BufferUsage.GL_STATIC_READ);
				BufferExtension.BindBuffer(BufferBindTarget.GL_ARRAY_BUFFER, 0);
				return new VertexBuffer(bufferNames[0]);
			}
			finally
			{
				if (handle != null && handle.IsAllocated)
				{
					handle.Free();
				}
			}
			throw new Exception("WTF???");
		}
	}
}
