using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Gfx;

namespace PandorasBox.OpenGL
{
	public abstract class AbstractGLGraphicDriver : IGraphicDriver
	{
		public AbstractGLGraphicDriver()
		{
			this.State = new GPUState();
		}

		public abstract void Bind();

		public abstract void Unbind();

		public abstract IntPtr GetGLEntryPoint(String entryPoint);

		public abstract IGPUTaskFactory TaskFactory { get; }

		public GPUState State{ get; private set; }

		public virtual void Dispose()
		{
			// TODO: implement
		}
		public virtual void OnRenderStarting()
		{
			this.ResourceFactory = new GLResourceFactory();
			BufferExtension.Initialize(this);
		}

		public GLResourceFactory ResourceFactory { get; private set; }
	}
}
