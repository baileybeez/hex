using Hex.Arcanum.Interfaces;
using System.Text;

namespace HexTests
{
	public class TestConsole : IConsole
	{
		private static readonly char[] kTrimChars = { '\r', '\n' };

		private readonly List<string> _logs = new();
		private readonly StringBuilder _sb = new();

		public IReadOnlyList<String> Logs => _logs;

		public void Write(string text)
		{
			string str = text.TrimEnd(kTrimChars);
			_sb.Append(str);
			if (text.EndsWith("\r") || text.EndsWith("\n"))
				Flush();
		}

		public void Flush()
		{
			if (_sb.Length > 0)
			{
				_logs.Add(_sb.ToString());
				_sb.Clear();
			}
		}
	}
}
