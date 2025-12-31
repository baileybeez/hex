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
			_handlerMap[LexemeTypes.EOF] = ParseEndOfFile;
			_handlerMap[LexemeTypes.NewLine] = ParseNewLine;
			_handlerMap[LexemeTypes.Whisper] = ParseWhisper;

			_handlerMap[LexemeTypes.Number] = ParseNumberLiteral;
			_handlerMap[LexemeTypes.True] = ParseBooleanLiteral;
			_handlerMap[LexemeTypes.False] = ParseBooleanLiteral;
			_handlerMap[LexemeTypes.Identifier] = ParseIdentifier;

			_handlerMap[LexemeTypes.OpenParen] = ParseParenthesizedExpression;

			_handlerMap[LexemeTypes.Conjure] = ParseConjure;
			_handlerMap[LexemeTypes.OpenScope] = ParseScope;
			_handlerMap[LexemeTypes.Ritual] = ParseRitualDeclaration;
			_handlerMap[LexemeTypes.EntryPoint] = ParseRitualDeclaration;
			_handlerMap[LexemeTypes.Return] = ParseReturnStatement;
		}
	}
}