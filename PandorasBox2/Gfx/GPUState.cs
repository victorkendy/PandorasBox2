using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandorasBox.Types;

namespace PandorasBox.Gfx
{
	public class GPUState
	{
		public bool DepthTestEnabled { get; private set; }

		public Color ClearColor { get; private set; }

		// TODO: change visibility to internal
		public void ChangeClearColor(Color color)
		{
			this.ClearColor = color;
		}

		public void EnableDepthTest() 
		{
			this.DepthTestEnabled = true;
		}

		public void DisableDepthTest()
		{
			this.DepthTestEnabled = false;
		}
	}
}
