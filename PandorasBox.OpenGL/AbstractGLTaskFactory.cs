using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Gfx;
using PandorasBox.OpenGL.PInvoke;
using PandorasBox.Types;

namespace PandorasBox.OpenGL
{
	public abstract class AbstractGLTaskFactory : IGPUTaskFactory
	{
		protected AbstractGLGraphicDriver driver;
		public AbstractGLTaskFactory(AbstractGLGraphicDriver driver)
		{
			this.driver = driver;
		}

		public IGPUTask ClearBuffers()
		{
			return new ClearScreenTask(driver);
		}

		public IGPUTask RenderSomething()
		{
			return new RenderSomethingTask(driver);
		}

		public abstract IGPUTask SwapBuffers();

		private class RenderSomethingTask : IGPUTask
		{
			private AbstractGLGraphicDriver driver;

			VertexBuffer buffer;

			public RenderSomethingTask(AbstractGLGraphicDriver driver)
			{
				this.driver = driver;
			}
			
			public void Execute()
			{
				if (buffer == null)
				{
					buffer = driver.ResourceFactory.CreateVertexBuffer();
				}
				GL.Color(1, 1, 1, 1);
				//GL.Begin(GLPrimitiveType.GL_TRIANGLES);
				//GL.Vertex(-1, 0, -0.5f, 1);
				//GL.Vertex(0, 1, -0.5f, 1);
				//GL.Vertex(1, 0, -0.5f, 1);
				//GL.End();
				buffer.Draw();
				Console.WriteLine(GL.GetError());
			}

			public bool ShouldExecute()
			{
				return true;
			}

			public GPUStateChange StateChange
			{
				get { return null; }
			}
		}

		private class ClearScreenTask : IGPUTask
		{
			private IGraphicDriver driver;
			public ClearScreenTask(IGraphicDriver driver)
			{
				this.driver = driver;
			}
			public void Execute()
			{
				Color color = driver.State.ClearColor;
				GL.ClearColor(color.Red, color.Green, color.Blue, color.Alpha);
				GL.Clear(GLClearBit.GL_COLOR_BUFFER_BIT);
			}
			public bool ShouldExecute()
			{
				return true;
			}
			public GPUStateChange StateChange { get; private set; }
		}

		
	}

	
}
