using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class BooleanLiteral : Expression
	{
		public bool Value { get; set; }

		public BooleanLiteral(bool value)
			: base(ExpressionTypes.BooleanLiteral)
		{
			Value = value;
		}
	}
}
