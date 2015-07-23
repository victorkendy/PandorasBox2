using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandorasBox.Types
{
	public struct Color
	{
		public float Red { get; private set; }

		public float Green { get; private set; }

		public float Blue { get; private set; }

		public float Alpha { get; private set; }

		public Color(float red, float green, float blue, float alpha = 1.0f):this()
		{
			this.Red = red;
			this.Green = green;
			this.Blue = blue;
			this.Alpha = alpha;
		}
	}
}
