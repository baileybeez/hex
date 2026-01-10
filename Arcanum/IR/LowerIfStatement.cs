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
			if (ifs.BranchList.Count == 0)
				return LowerSimpleIfStatement(ifs);

			string termLabel = NewLabel();
			string nextLabel = NewLabel();
			string ret = LowerExpression(ifs.Condition);

			Emit(OpCode.JumpIfFalse, ret, nextLabel);
			LowerScope(ifs.InnerScope);
			Emit(OpCode.Jump, String.Empty, termLabel);
			Emit(OpCode.Label, nextLabel);
			for (int idx = 0; idx < ifs.BranchList.Count; idx++)
			{
				nextLabel = NewLabel();

				bool last = idx + 1 == ifs.BranchList.Count;
				var branch = ifs.BranchList[idx];
				if (branch.Condition.Type != ExpressionTypes.DefaultCondition)
				{
					ret = LowerExpression(branch.Condition);
					Emit(OpCode.JumpIfFalse, ret, last ? termLabel : nextLabel);
				}

				LowerScope(branch.InnerScope);
				if (!last)
				{
					Emit(OpCode.Jump, String.Empty, termLabel);
					Emit(OpCode.Label, nextLabel);
				}
			}

			Emit(OpCode.Label, termLabel);

			return String.Empty;
		}

		public string LowerSimpleIfStatement(IfStatement ifs)
		{
			string termLabel = NewLabel();
			string ret = LowerExpression(ifs.Condition);

			Emit(OpCode.JumpIfFalse, ret, termLabel);
			LowerScope(ifs.InnerScope);
			Emit(OpCode.Label, termLabel);

			return String.Empty;
		}
	}
}
