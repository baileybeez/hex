using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerParenthesized(Expression expr)
		{
			var paren = AssertValid<ParenthesizedStatement>(expr);

			return LowerExpression(paren.InnerExpression);
		}
	}
}
