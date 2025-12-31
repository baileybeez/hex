using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerWhileStatement(Expression expr)
		{
			var ifs = AssertValid<WhileStatement>(expr);

			string startLabel = NewLabel();
			string termLabel = NewLabel();

			Emit(OpCode.Label, startLabel);
			string ret = LowerExpression(ifs.Condition);
			Emit(OpCode.JumpIfFalse, ret, termLabel);
			LowerScope(ifs.InnerScope);
			Emit(OpCode.Jump, String.Empty, startLabel);
			Emit(OpCode.Label, termLabel);

			return String.Empty;
		}
	}
}
