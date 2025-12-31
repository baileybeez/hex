using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseWhisper()
		{
			string text = "";

			Require(LexemeTypes.Whisper);
			Lexeme phrase = NextLexeme();
			switch (phrase.Type)
			{
				default:
					throw new UnexpectedLexemeException(phrase, $"Expected proper whisper phrase");
				
				case LexemeTypes.String:
				case LexemeTypes.Identifier:
					text = phrase.Text;
					break;
			}

			return new Whisper(text);
		}
	}
}