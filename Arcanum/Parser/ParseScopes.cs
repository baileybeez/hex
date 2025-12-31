using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseScope()
		{
			Require(LexemeTypes.OpenScope);
			return Peek().Type switch
			{
				LexemeTypes.If => ParseIfStatement(),
				LexemeTypes.While => ParseWhileStatement(),
				LexemeTypes.Weave => ParseForStatement(),
				_ => throw new UnexpectedLexemeException(Peek(), $"Expected valid circle incantation.")
			};
		}
	}
}