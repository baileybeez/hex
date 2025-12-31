using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerForStatement(Expression expr)
		{
			var frs = AssertValid<ForStatement>(expr);

			string startLabel = NewLabel();
			string termLabel = NewLabel();

			string itr = NewTemp();
			string truth = NewTemp();
			string swap = NewTemp();
			string end = LowerExpression(frs.To);

			Emit(OpCode.Copy, itr, LowerExpression(frs.From));
			Emit(OpCode.Label, startLabel);
			Emit(OpCode.GreaterEqual, truth, itr, end);
			Emit(OpCode.JumpIfTrue, truth, termLabel);
			Emit(OpCode.Inc, swap, itr);
			Emit(OpCode.Copy, itr, swap);
			LowerScope(frs.InnerScope);
			Emit(OpCode.Jump, String.Empty, startLabel);
			Emit(OpCode.Label, termLabel);

			return String.Empty;
		}
	}
}
