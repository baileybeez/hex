using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	/*
	⚝ ᚠᛇᛒ → 🜔
   🝣🝥
      🝀 🜔 ᚷᛖᚾ 🜃 ↷
   ◯⟥
      <scope statements>
   ⟤
	 */
	public sealed partial class Parser
	{
		public Expression? ParseRitualDeclaration()
		{
			Scope programScope = _scopeStack.Peek();
			if (programScope.ScopeType != ScopeTypes.Global)
				throw new HexException("Rituals must be declared at the root scope.");

			bool entryPoint = false;
			if (Peek().Type == LexemeTypes.EntryPoint)
			{
				Require(LexemeTypes.EntryPoint);
				// TODO: validate entrypoint isn't already set
				entryPoint = true;
			}

			Require(LexemeTypes.Ritual);
			var idFunc = Require(LexemeTypes.Identifier);
			// TODO: validate function name isn't duplicate
			Require(LexemeTypes.RightArrow);
			VariableTypes retType = ParseVariableType();
			SkipIf(LexemeTypes.NewLine);

			List<FunctionParam> paramList = new();
			if (Peek().Type == LexemeTypes.Conjure)
			{
				Require(LexemeTypes.Conjure);
				Require(LexemeTypes.Cauldron);
				SkipIf(LexemeTypes.NewLine);
				while (Peek().Type == LexemeTypes.Place)
				{
					Require(LexemeTypes.Place);
					VariableFlags paramFlag = ParseVariableFlag();
					VariableTypes paramType = ParseVariableType();
					var idParam = Require(LexemeTypes.Identifier);
					StirDirection paramStir = ParseStirDirection();
					Require(LexemeTypes.NewLine);

					paramList.Add(new FunctionParam(idParam.Text, paramType, paramFlag, paramStir));
				}
			}
			SkipIf(LexemeTypes.NewLine);
			Require(LexemeTypes.Circle);
			Require(LexemeTypes.OpenScope);
			SkipIf(LexemeTypes.NewLine);

			Scope fncScope = CreateScope(ScopeTypes.Function);
			while (Peek().Type != LexemeTypes.CloseScope)
			{
				Expression? expr = ParseExpression();
				if (expr != null)
					fncScope.AddExpression(expr);

				SkipIf(LexemeTypes.NewLine);
			}
			Require(LexemeTypes.CloseScope);
			PopScope();

			return new FunctionDeclaration(idFunc.Text, retType, paramList, fncScope, entryPoint);
		}
	}
}
