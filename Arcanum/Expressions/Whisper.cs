using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class Whisper : Expression
	{
		public Expression TextExpression { get; private set; }

		public Whisper(Expression expr) 
			: base(ExpressionTypes.Whisper)
		{
			TextExpression = expr; 
		}
	}
}
