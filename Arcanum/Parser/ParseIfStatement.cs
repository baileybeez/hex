using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		// ⟥ ↝ ᛖ > 0 \r\n <scope statements> \r\n ⟤ 
		public Expression? ParseIfStatement()
		{
			var lex = Require(LexemeTypes.If);
			Expression? cond = ParseExpression();
			if (cond == null)
				throw new HexException($"Invalid condition for conditional circle at line {lex.LineNo}, col {lex.Col}");

			SkipIf(LexemeTypes.NewLine);
			Scope ifScope = new Scope(_scopeStack.Peek(), ScopeTypes.Local);
			IfStatement ifs = new IfStatement(cond, ifScope);

			Expression? branchCondition = null;
			Scope? elseBranch = null;
			bool hasDefault = false;
			
			Scope curBranch = ifScope;
			while (true)
			{
				Lexeme next = Peek();
				if (next.Type == LexemeTypes.CloseScope)
					break;

				if (next.Type == LexemeTypes.ElseIf || next.Type == LexemeTypes.Else)
				{
					if (hasDefault)
						throw new HexException($"Conditional circle cannot declare more branches, it already has a fallback. Line {next.LineNo}, col {next.Col}");

					elseBranch = new Scope(_scopeStack.Peek(), ScopeTypes.Local);
					branchCondition = null;
					if (next.Type == LexemeTypes.Else)
					{
						Require(LexemeTypes.Else);
						hasDefault = true;
						branchCondition = new DefaultCondition();
					}
					else if (next.Type == LexemeTypes.ElseIf)
					{
						Require(LexemeTypes.ElseIf);
						Require(LexemeTypes.If);
						branchCondition = ParseExpression();
					}

					if (branchCondition == null)
						throw new HexException($"Invalid condition for conditional circle at line {next.LineNo}, col {next.Col}");

					ifs.PushBranch(branchCondition, elseBranch);
					curBranch = elseBranch;
				}
				else
				{
					Expression? expr = ParseExpression();
					if (expr != null)
						curBranch.AddExpression(expr);
				}

				SkipIf(LexemeTypes.NewLine);
			}
			Require(LexemeTypes.CloseScope);

			return ifs;
		}
	}
}