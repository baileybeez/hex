using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseEndOfFile() 
		{
			if (_scopeStack.Count > 1)
				throw new UnexpectedLexemeException(NextLexeme(), $"Expected closure of {_scopeStack.Count} circle(s)");

			return null;
		}
	}
}