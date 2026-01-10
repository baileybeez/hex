using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		// ⟥ ⇄ ᛖ 0 ⇒ 10 \r\n \r\n ⟤
		public Expression? ParseForStatement()
		{
			var lex = Require(LexemeTypes.Weave);
			NamedStatement? named = ParseIdentifier() as NamedStatement;
			Expression? from = ParseExpression();
			Require(LexemeTypes.To);
			Expression? to = ParseExpression();
			if (named == null || from == null || to == null)
				throw new HexException($"Invalid format for woven circle at line {lex.LineNo}, col {lex.Col}");
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

			return new ForStatement(named, from, to, innerScope);
		}
	}
}