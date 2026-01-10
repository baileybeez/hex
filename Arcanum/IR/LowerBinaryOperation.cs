using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerBinaryOperation(Expression expr)
		{
			var binOp = AssertValid<BinaryOperation>(expr);

			string leftTemp = LowerExpression(binOp.Left);
			string rightTemp = LowerExpression(binOp.Right);

			string resultTemp = NewTemp();
			OpCode opcode = binOp.Operator switch
			{
				BinaryOperatorTypes.Addition => OpCode.Add, 
				BinaryOperatorTypes.Subtraction => OpCode.Sub,
				BinaryOperatorTypes.Multiplication => OpCode.Mul,
				BinaryOperatorTypes.Division => OpCode.Div,
				BinaryOperatorTypes.Modulus => OpCode.Mod,
				BinaryOperatorTypes.Equality => OpCode.Equal,
				BinaryOperatorTypes.Inequality => OpCode.NotEqual,
				BinaryOperatorTypes.GreaterThan => OpCode.Greater,
				BinaryOperatorTypes.GreaterThanEquals => OpCode.GreaterEqual,
				BinaryOperatorTypes.LessThan => OpCode.Less,
				BinaryOperatorTypes.LessThanEquals => OpCode.LessEqual,
				BinaryOperatorTypes.And => OpCode.And,
				BinaryOperatorTypes.Or => OpCode.Or,
				_ => throw new NotImplementedException($"Operator {binOp.Operator} not implemented.")
			};

			Emit(opcode, resultTemp, leftTemp, rightTemp);
			return resultTemp;
		}
	}
}
