using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Gfx;
using PandorasBox.OpenGL;
using PandorasBox2.OS.Win32.OpenGL;

namespace PandorasBox.OS.Win32.OpenGL.PInvoke
{
	public class Win32GLTaskFactory : AbstractGLTaskFactory
	{
		IntPtr hdc;
		IntPtr hglrc;
		public Win32GLTaskFactory(AbstractGLGraphicDriver driver, IntPtr hdc, IntPtr hglrc):base(driver)
		{
			this.hdc = hdc;
			this.hglrc = hglrc;
		}

		public override Gfx.IGPUTask SwapBuffers()
		{
			return new SwapBuffersTask(hdc);
		}

		private class SwapBuffersTask : IGPUTask
		{
			private IntPtr hdc;
			public SwapBuffersTask(IntPtr hdc)
			{
				this.hdc = hdc;
			}
			public void Execute()
			{
				WGL.SwapBuffers(hdc);
			}

			public bool ShouldExecute()
			{
				return true;
			}

			public GPUStateChange StateChange
			{
				get { throw new NotImplementedException(); }
			}
		}
	}
}
