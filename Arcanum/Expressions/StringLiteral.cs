using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class StringLiteral : Expression
	{
		public string Value { get; private set; }

		public StringLiteral(string text)
			: base(ExpressionTypes.StringLiteral)
		{
			Value = text;
		}
	}
}
