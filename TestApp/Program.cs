using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PandorasBox.Gfx;
using PandorasBox.Logging;
using PandorasBox.OpenGL.PInvoke;
using PandorasBox.OS.Win32;
using PandorasBox.OS.Win32.OpenGL;
using PandorasBox.Types;
using PandorasBox2.OS.Win32.OpenGL;
using PandorasBox2.OS.Win32.PInvoke;

namespace TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			log4net.Config.XmlConfigurator.Configure();
			using (var factory = new WindowFactory(new GLGraphicDriverFactory()))
			using (var window = factory.CreateWindow(new PandorasBox.Gfx.WindowConfiguration
			{
				Fullscreen = false,
				Width = 800,
				Height = 600,
				Title = "Minha Janelinha"
			}))
			{
				window.GraphicDriver.State.ChangeClearColor(new Color(0, 0, 0));
				IGPUTaskFactory taskFactory = window.GraphicDriver.TaskFactory;
				IList<IGPUTask> tasks = new List<IGPUTask>
				{
					taskFactory.ClearBuffers(), taskFactory.RenderSomething(), taskFactory.SwapBuffers()
				};
				window.Renderer.ChangeTasks(tasks);
				window.Show();
				new Win32MessagePump().PumpMessages();
			}
		}
	}
}
