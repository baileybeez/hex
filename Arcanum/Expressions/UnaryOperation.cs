using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Expressions
{
	public enum UnaryOperatorTypes
	{
		Unknown = 0,

		Invert = 1,

		Amplify = 10,
		Diminish = 11,
	}

	public sealed class UnaryOperation : Expression
	{
		public UnaryOperatorTypes Operator { get; private set; }
		public Expression Right { get; private set; }

		public UnaryOperation(LexemeTypes opType, Expression right)
			: base(ExpressionTypes.UnaryOp)
		{
			Operator = DetermineOperator(opType);
			Right = right;
		}

		public UnaryOperatorTypes DetermineOperator(LexemeTypes opType)
		{
			return opType switch
			{
				LexemeTypes.Bang => UnaryOperatorTypes.Invert,
				LexemeTypes.Amplify => UnaryOperatorTypes.Amplify,
				LexemeTypes.Diminish => UnaryOperatorTypes.Diminish,
				_ => throw new HexException($"Unhandled unary operator '{opType}'")
			};
		}
	}
}
