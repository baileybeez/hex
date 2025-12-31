using Hex.Arcanum.Common;

namespace Hex.Arcanum.Exceptions
{
	public sealed class UnexpectedLexemeException : HexException
	{
		public UnexpectedLexemeException(Lexeme lex, string? expected = null) 
			: base($"Unexpected {lex.Type} '{lex.Text}' at line {lex.LineNo}, col {lex.Col} {(expected == null ? "" : $"\r\r{expected}")}")
		{
		}
	}
}
