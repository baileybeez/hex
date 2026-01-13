using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class CharLiteral : Expression
	{
		public char Value { get; private set; }

		public CharLiteral(char val) : base(ExpressionTypes.CharLiteral)
		{
			Value = val;
		}
	}
}
