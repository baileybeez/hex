using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerAssignment(Expression expr)
		{
			var assign = AssertValid<AssignmentStatement>(expr);

			string? varTemp = LookupVar(assign.VarName);
			if (varTemp == null)
			{
				varTemp = NewTemp();
				AddVar(assign.VarName, varTemp);
			}

			string valTemp = LowerExpression(assign.ValueExpression);
			Emit(OpCode.Copy, varTemp, valTemp);

			return varTemp;
		}
	}
}
