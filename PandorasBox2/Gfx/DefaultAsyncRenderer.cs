using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PandorasBox.Logging;

namespace PandorasBox.Gfx
{
	public class DefaultAsyncRenderer : IAsyncRenderer
	{
		private static readonly int QuitRenderingTimeout = 500;

		private ILog logger = Logger.Get<DefaultAsyncRenderer>();

		private Thread renderingThread;
		private IGraphicDriver graphicDriver;
		// FIXME: send terminate message
		private volatile bool quitRendering;
		private IList<IGPUTask> tasks;
		

		public DefaultAsyncRenderer(IGraphicDriver driver)
		{
			this.graphicDriver = driver;
			this.renderingThread = new Thread(() =>
			{
				driver.Bind();
				driver.OnRenderStarting();
				logger.Debug("Beggining Async Rendering Thread");
				while (!quitRendering)
				{
					foreach(IGPUTask task in tasks) 
					{
						if (task.ShouldExecute())
						{
							task.Execute();
						}
					}
					Thread.Sleep(500);
				}
				logger.Debug("Terminating Async Rendering Thread");
				driver.Unbind();
			});
		}

		public void Start()
		{
			this.quitRendering = false;
			renderingThread.Start();
		}

		public void Stop()
		{
			logger.Debug("Stopping Rendering Thread");
			quitRendering = true;
			renderingThread.Join(QuitRenderingTimeout);
			if (renderingThread.IsAlive)
			{
				// if the thread is still alive after the timeout abort it
				renderingThread.Abort();
			}
		}


		public void ChangeTasks(IList<IGPUTask> tasks)
		{
			this.tasks = tasks;
		}
	}
}
