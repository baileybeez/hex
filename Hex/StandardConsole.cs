using Hex.Arcanum.Interfaces;

namespace Hex
{
	public sealed class StandardConsole : IConsole
	{
		private static readonly char[] kTrimChars = { '\r', '\n' };

		public void Write(string text)
		{
			string str = text.TrimEnd(kTrimChars);
			Console.Write(str);
			if (text.EndsWith("\r") || text.EndsWith("\n"))
				Flush();
		}

		public void Flush()
		{
			Console.WriteLine("");
		}
	}
}
