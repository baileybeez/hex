using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		private Dictionary<LexemeTypes, Func<Expression?>> _handlerMap = new();

		private void SetupHandlerMap()
		{
			_handlerMap.Clear();
			_handlerMap.Add(LexemeTypes.EOF, ParseEndOfFile);
			_handlerMap.Add(LexemeTypes.NewLine, ParseNewLine);
			_handlerMap.Add(LexemeTypes.Whisper, ParseWhisper);

			_handlerMap.Add(LexemeTypes.Number, ParseNumberLiteral);
			_handlerMap.Add(LexemeTypes.Char, ParseCharLiteral);
			_handlerMap.Add(LexemeTypes.String, ParseStringLiteral);
			_handlerMap.Add(LexemeTypes.True, ParseBooleanLiteral);
			_handlerMap.Add(LexemeTypes.False, ParseBooleanLiteral);
			_handlerMap.Add(LexemeTypes.Identifier, ParseIdentifier);

			_handlerMap.Add(LexemeTypes.OpenParen, ParseParenthesizedExpression);

			_handlerMap.Add(LexemeTypes.Conjure, ParseConjure);
			_handlerMap.Add(LexemeTypes.OpenScope, ParseScope);
			_handlerMap.Add(LexemeTypes.Ritual, ParseRitualDeclaration);
			_handlerMap.Add(LexemeTypes.EntryPoint, ParseRitualDeclaration);
			_handlerMap.Add(LexemeTypes.Return, ParseReturnStatement);
		}
	}
}