using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Expressions
{
   public enum BinaryOperatorTypes
   {
      Unknown = 0,

      // Arithmetic
      Addition = 1,
      Subtraction = 2,
      Multiplication = 3,
      Division = 4,

      // Logic
      Equality = 10,
      Inequality = 11,
      GreaterThan = 12,
      GreaterThanEquals = 13,
		LessThan = 14,
		LessThanEquals = 15,
	}

	public sealed class BinaryOperation : Expression
   {
      public Expression Left { get; private set; }
      public BinaryOperatorTypes Operator { get; private set; }
      public Expression Right { get; private set; }

      public BinaryOperation(Expression left, LexemeTypes opType, Expression right)
         : base(ExpressionTypes.BinaryOp)
      {
         Left = left;
         Operator = DetermineOperand(opType);
         Right = right;
      }

      public BinaryOperatorTypes DetermineOperand(LexemeTypes type)
      {
         return type switch
         {
            LexemeTypes.Plus => BinaryOperatorTypes.Addition,
            LexemeTypes.Minus => BinaryOperatorTypes.Subtraction,
            LexemeTypes.Times => BinaryOperatorTypes.Multiplication,
            LexemeTypes.Slash => BinaryOperatorTypes.Division,
            LexemeTypes.Equality => BinaryOperatorTypes.Equality,
            LexemeTypes.Inequality => BinaryOperatorTypes.Inequality,
            LexemeTypes.GreaterThan => BinaryOperatorTypes.GreaterThan,
            LexemeTypes.GreaterThanEquals => BinaryOperatorTypes.GreaterThanEquals,
            LexemeTypes.LessThan => BinaryOperatorTypes.LessThan,
            LexemeTypes.LessThanEquals => BinaryOperatorTypes.LessThanEquals,
				_ => throw new HexException($"Unhandled binary operator '{type}'")
         };
      }
   }
}
