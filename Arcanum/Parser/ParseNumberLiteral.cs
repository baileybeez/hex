using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseNumberLiteral()
		{
			Lexeme lex = Require(LexemeTypes.Number);
			if (!uint.TryParse(lex.Text, out uint n))
				throw new HexException($"Failed to parse number literal from '{lex.Text}'");

			return new U64Literal(n);
		}
	}
}