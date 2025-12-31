using Hex.Arcanum.Interfaces;

namespace Hex
{
	public sealed class StandardConsole : IConsole
	{
		public void Write(string text)
		{
			Console.Write(text.TrimEnd());
			if (text.EndsWith("\r") || text.EndsWith("\n"))
				Flush();
		}

		public void Flush()
		{
			Console.WriteLine("");
		}
	}
}
