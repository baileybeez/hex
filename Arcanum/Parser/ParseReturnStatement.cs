using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseReturnStatement()
		{
			Require(LexemeTypes.Return);

			var expr = ParseExpression();
			if (expr == null)
				throw new HexException($"Invalid or missing syntax while parsing a return statement.");

			return new ReturnStatement(expr);
		}
	}
}