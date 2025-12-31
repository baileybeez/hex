using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class Whisper : Expression
	{
		public string Text { get; private set; }

		public Whisper(string str) 
			: base(ExpressionTypes.Whisper)
		{
			Text = str; 
		}
	}
}
