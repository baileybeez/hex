using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerIfStatement(Expression expr)
		{
			var ifs = AssertValid<IfStatement>(expr);

			string termLabel = NewLabel();
			string ret = LowerExpression(ifs.Condition);
			Emit(OpCode.JumpIfFalse, ret, termLabel);
			LowerScope(ifs.InnerScope);
			Emit(OpCode.Label, termLabel);

			return String.Empty;
		}
	}
}
