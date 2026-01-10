using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseWhisper()
		{
			Expression? exprVal = null;

			Require(LexemeTypes.Whisper);
			Lexeme phrase = NextLexeme();
			switch (phrase.Type)
			{
				default: 
					break;
				
				case LexemeTypes.String:
					exprVal = new StringLiteral(phrase.Text);
					break;

				case LexemeTypes.Identifier:
					exprVal = new NamedStatement(phrase.Text);
					break;
			}

			if (exprVal == null)
				throw new UnexpectedLexemeException(phrase, $"Expected proper whisper phrase");

			return new Whisper(exprVal);
		}
	}
}