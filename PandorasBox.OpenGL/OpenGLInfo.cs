using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PandorasBox.OpenGL
{
	public class OpenGLInfo
	{
		public int MajorVersion { get; private set; }
		public int MinorVersion { get; private set; }
		public int? BuildNumber { get; private set; }

		public static readonly Regex GLVersionRegex = new Regex("^(\\d+)\\.(\\d+)(\\.(\\d+))?.*$");
		public OpenGLInfo(String glVersionString)
		{
			var match = GLVersionRegex.Match(glVersionString);
			if (match.Success)
			{
				this.MajorVersion = int.Parse(match.Groups[1].Value);
				this.MinorVersion = int.Parse(match.Groups[2].Value);

				if (match.Groups[3].Success)
				{
					this.BuildNumber = int.Parse(match.Groups[4].Value);
				}
			}
			else
			{
				throw new ArgumentException("Invalid OpenGL Version String");
			}
		}

		public override string ToString()
		{
			return String.Format("{0}.{1}.{2}", MajorVersion, MinorVersion, BuildNumber);
		}
	}
}
