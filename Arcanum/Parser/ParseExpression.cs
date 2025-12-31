using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public Expression? ParseExpression(int precParent = Precendence.kDefault)
		{
			Expression? left = null;

			int precUnary = Precendence.GetUnary(Peek().Type);
			if (precUnary != Precendence.kDefault && precUnary >= precParent)
			{
				Lexeme opToken = NextLexeme();
				Expression? right = ParseExpression(precUnary);
				if (right == null)
					throw new HexException($"Expected right hand expression for {opToken}");

				left = new UnaryOperation(opToken.Type, right);
			}
			else
				left = ParsePrimaryExpression();

			while (true)
			{
				int precBinary = Precendence.GetBinary(Peek().Type);
				if (precBinary == Precendence.kDefault || precBinary <= precParent)
					break;

				Lexeme opToken = NextLexeme();
				Expression? right = ParseExpression(precBinary);
				if (left == null)
					throw new HexException($"Expected left hand expression for {opToken}");

				if (right == null)
					throw new HexException($"Expected right hand expression for {opToken}");

				left = new BinaryOperation(left, opToken.Type, right);
			}

			return left;
		}
	}
}