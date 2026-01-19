using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseConjure()
		{
			Require(LexemeTypes.Conjure);
			switch (Peek().Type)
			{
				default:
					throw new UnexpectedLexemeException(Peek(), $"Expected valid type of conjuration.");
				case LexemeTypes.Cauldron:
				 	return ParseRitualInvokation();
				case LexemeTypes.Fire:
				case LexemeTypes.Earth:
					return ParseVariableConjure();
			}
		}

		/*
		 🝣🝥
		 🝀 ᚷᛖᚾ 🝥 ↷
		 🝠 ᚠᛇᛒ

		 ::
		 conjure cauldron
		 place GEN into cauldron and stir clockwise
		 invoke FIB
		 */
		public Expression? ParseRitualInvokation()
		{
			var marker = Require(LexemeTypes.Cauldron);
			SkipIf(LexemeTypes.NewLine);

			// parameters
			List<InvokationParam> paramList = new();
			while (Peek().Type == LexemeTypes.Place)
			{
				Require(LexemeTypes.Place);
				var exprParam = ParseExpression();
				if (exprParam == null)
					throw new HexException($"Invalid syntax while parsing ritual invokation on line {marker.LineNo}, col {marker.Col}");

				Require(LexemeTypes.Cauldron);
				StirDirection paramStir = ParseStirDirection();
				
				paramList.Add(new InvokationParam(exprParam, paramStir));
				SkipIf(LexemeTypes.NewLine);
			}
			Require(LexemeTypes.Invoke);
			Lexeme identifier = Require(LexemeTypes.Identifier);

			// TODO: validation

			// TODO: check for retval
			string retvar = String.Empty;
			if (Peek().Type == LexemeTypes.To)
			{
				Require(LexemeTypes.To);
				Lexeme lexRet = Require(LexemeTypes.Identifier);
				// TODO: validate var

				retvar = lexRet.Text;
			}

			return new FunctionInvokation(identifier.Text, paramList, retvar);
		}

		public Expression? ParseVariableConjure()
		{
			// 🝣 🜂 🜔 ᚫ ← 1			:: `conjure fire salt A as 1`
			VariableFlags varFlag = ParseVariableFlag();
			VariableTypes varType = ParseVariableType();
			Lexeme identifier = Require(LexemeTypes.Identifier);
			ValidateUnusedIdentifier(identifier.Text);

			Variable newVar = AddVar(identifier.Text, varType, varFlag);
			Expression? exprVal = null;
			if (Peek().Type == LexemeTypes.LeftArrow)
			{
				NextLexeme();
				exprVal = ParseExpression();
			}

			return new VariableConjuration(identifier.Text, varType, varFlag, exprVal);
		}

		public VariableTypes LookupVariableType(LexemeTypes lexType)
		{
			if (_varTypeMap.ContainsKey(lexType))
				return _varTypeMap[lexType];

			return VariableTypes.Unknown;
		}

		public VariableTypes ParseVariableType()
		{
			Lexeme lex = NextLexeme();
			VariableTypes varType = LookupVariableType(lex.Type);
			if (varType == VariableTypes.Unknown)
				throw new UnexpectedLexemeException(lex, $"Expected valid variable type.");

			return varType;
		}

		public VariableFlags LookupVariableFlag(LexemeTypes lexFlag)
		{
			if (_varFlagsMap.ContainsKey(lexFlag))
				return _varFlagsMap[lexFlag];

			return VariableFlags.Unknown;
		}

		public VariableFlags ParseVariableFlag()
		{
			Lexeme lexFlag = NextLexeme();
			VariableFlags flag = LookupVariableFlag(lexFlag.Type);
			if (flag == VariableFlags.Unknown)
				throw new UnexpectedLexemeException(lexFlag, $"Expected valid variable flag.");

			return flag;
		}

		public StirDirection ParseStirDirection()
		{
			Lexeme stir = NextLexeme();
			if (stir.Type == LexemeTypes.StirCW)
				return StirDirection.Clockwise;
			else if (stir.Type == LexemeTypes.StirCCW)
				return StirDirection.CounterClockwise;

			throw new UnexpectedLexemeException(stir, $"Expected stir declaration.");
		}
	}
}