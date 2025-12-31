using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		// ⟥ ↻ ᛖ > 0 \r\n \r\n ⟤
		public Expression? ParseWhileStatement()
		{
			var lex = Require(LexemeTypes.While);
			Expression? cond = ParseExpression();
			if (cond == null)
				throw new HexException($"Invalid condition for conditional circle at line {lex.LineNo}, col {lex.Col}");
			SkipIf(LexemeTypes.NewLine);

			Scope innerScope = new Scope(_scopeStack.Peek(), ScopeTypes.Local);
			while (Peek().Type != LexemeTypes.CloseScope)
			{
				Expression? expr = ParseExpression();
				if (expr != null)
					innerScope.AddExpression(expr);

				SkipIf(LexemeTypes.NewLine);
			}
			Require(LexemeTypes.CloseScope);

			return new WhileStatement(cond, innerScope);
		}
	}
}