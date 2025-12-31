
using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Lexeme Peek(int offset = 0)
		{
			int idx = _pos + offset;
			if (idx < 0 || idx >= _lexList.Count)
				return kEndOfFileLexeme;

			return _lexList[idx];
		}

		public Lexeme NextLexeme()
		{
			Lexeme lex = Peek();
			_pos++;
			return lex;
		}

		public void SkipIf(LexemeTypes optType)
		{
			while (Peek().Type == optType)
				NextLexeme();
		}

		public Lexeme Require(LexemeTypes reqType)
		{
			Lexeme lex = NextLexeme();
			if (lex.Type != reqType)
				throw new UnexpectedLexemeException(lex, $"Expected {reqType} but found {lex.Type}");

			return lex;
		}
	}
}
