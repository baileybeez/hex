using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseBooleanLiteral()
		{
			Lexeme lex = NextLexeme();
			return lex.Type switch
			{
				LexemeTypes.True => new BooleanLiteral(true),
				LexemeTypes.False => new BooleanLiteral(false),
				_ => throw new HexException($"Failed to parse boolean literal from '{lex.Text}'")
			};
		}
	}
}
