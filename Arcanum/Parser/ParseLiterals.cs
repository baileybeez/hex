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
		
		public Expression? ParseCharLiteral()
		{
			Lexeme lex = Require(LexemeTypes.Char);
			char cb = ' ';
			if (lex.Text.Length == 1)
				cb = lex.Text[0];

			return new CharLiteral(cb);
		}

		public Expression? ParseStringLiteral()
		{
			Lexeme lex = Require(LexemeTypes.String);
			
			return new StringLiteral(lex.Text);
		}
	}
}