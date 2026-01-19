using System.Text;

namespace Hex.Arcanum.Lexer
{
	public sealed class LexerState
	{
		public int State { get; private set; } = Lexer.kState_Idle;
		public int Line { get; private set; } = 1;
		public int Col { get; private set; } = 0;

		private readonly StringBuilder _accum = new();

		public LexerState(int lineNo)
		{
			Line = lineNo;
		}

		public string Value() => _accum.ToString();
		public int Len() => _accum.Length;

		public void Push(Rune rune) => _accum.Append(rune);

		public void Reset()
		{
			State = Lexer.kState_Idle;
			Col = 0;
			_accum.Clear();
		}

		public void SwitchTo(int state, int col, Rune rune)
		{
			State = state;
			Col = col;
			if (rune.Value != ' ')
				_accum.Append(rune);
		}
	}
}
