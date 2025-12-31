using Hex.Arcanum.Common;
using System.Reflection;

namespace Hex.App
{
	public sealed partial class App
	{
		public void PrintVersion()
		{
			Assembly asm = typeof(RuneCodes).Assembly;
			var ver = asm.GetName().Version;
			if (ver != null)
				Console.WriteLine($"{ver.Major}.{ver.Minor}.{ver.Build}");
		}
	}
}