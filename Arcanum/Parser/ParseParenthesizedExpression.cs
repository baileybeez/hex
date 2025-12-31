using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseParenthesizedExpression()
		{
			var paren = Require(Common.LexemeTypes.OpenParen);
			var expr = ParseExpression();
			if (expr == null)
				throw new HexException($"Invalid expression encountered at line {paren.LineNo}, column {paren.Col}");
			Require(Common.LexemeTypes.CloseParen);

			return new ParenthesizedStatement(expr);
		}
	}
}