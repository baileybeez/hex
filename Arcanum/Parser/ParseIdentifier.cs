using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseIdentifier()
		{
			var identifier = Require(LexemeTypes.Identifier);
			if (Peek().Type == LexemeTypes.LeftArrow)
			{
				Variable? var = LookupVar(identifier.Text);
				if (var == null)
					throw new HexException($"Variable {identifier.Text} used before being conjured.");

				NextLexeme();
				Expression? right = ParseExpression();
				if (right == null)
					throw new HexException("Expected right hand value for assignment operation.");

				return new AssignmentStatement(identifier.Text, var.Type, right);
			}

			return new NamedStatement(identifier.Text);
		}
	}
}