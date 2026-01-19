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

			string swap = frs.VarName.Name;
			string? itr = LookupMappedVar(frs.VarName.Name);
			if (itr == null)
			{
				itr = NewTemp();
				AddVariable(frs.VarName.Name, VariableTypes.U64, VariableFlags.Volitile);
				AddMappedVar(frs.VarName.Name, itr);
			}
			string truth = NewTemp();
			string end = LowerExpression(frs.To);

			Emit(OpCode.CopyU64, itr, LowerExpression(frs.From));
			Emit(OpCode.Label, startLabel);
			Emit(OpCode.Greater, truth, itr, end);
			Emit(OpCode.JumpIfTrue, truth, termLabel);
			LowerScope(frs.InnerScope);
			Emit(OpCode.Inc, itr, itr);
			Emit(OpCode.Jump, String.Empty, startLabel);
			Emit(OpCode.Label, termLabel);

			return String.Empty;
		}
	}
}
