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

			string temp = LowerExpression(assign.ValueExpression);
			Emit(OpCode.Copy, assign.VarName, temp);

			return assign.VarName;
		}
	}
}
