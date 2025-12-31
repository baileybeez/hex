using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseNewLine()
		{
			NextLexeme();  // skip new line
			return ParseExpression();
		}
	}
}