using Hex.Arcanum.Interfaces;
using System.Text;

namespace HexTests
{
	public class TestConsole : IConsole
	{
		private readonly List<string> _logs = new();
		private readonly StringBuilder _sb = new();

		public IReadOnlyList<String> Logs => _logs;

		public void Write(string str)
		{
			_sb.Append(str.TrimEnd());
			if (str.EndsWith("\r") || str.EndsWith("\n"))
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
