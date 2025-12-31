using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParsePrimaryExpression()
		{
			LexemeTypes type = Peek().Type;
			if (_handlerMap.TryGetValue(type, out var func))
				return func();

			throw new UnexpectedLexemeException(Peek());
		}
	}
}