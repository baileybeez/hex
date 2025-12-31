using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerUnaryOperation(Expression expr)
		{
			var unary = AssertValid<UnaryOperation>(expr);

			string resultTemp = NewTemp();
			switch (unary.Operator)
			{
				default:
					throw new NotImplementedException($"Operator {unary.Operator} not implemented.");
				case UnaryOperatorTypes.Invert:
					Emit(OpCode.Not, resultTemp, LowerExpression(unary.Right));
					break;
				case UnaryOperatorTypes.Amplify:
				case UnaryOperatorTypes.Diminish:
					{
						var named = AssertValid<NamedStatement>(unary.Right);
						var code = unary.Operator == UnaryOperatorTypes.Amplify ? OpCode.Inc : OpCode.Dec;
						
						// perform INC / DEC then copy value back into var
						Emit(code, resultTemp, named.Name);
						Emit(OpCode.Copy, named.Name, resultTemp);
					}
					break;
			}
			
			return resultTemp;
		}
	}
}
