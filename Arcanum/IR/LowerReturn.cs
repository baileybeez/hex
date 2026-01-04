using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerReturn(Expression expr)
		{
			var ret = AssertValid<ReturnStatement>(expr);
			if (ret.Expression != null)
			{
				var retVal = LowerExpression(ret.Expression);
				Emit(OpCode.CopyToReg, "RAX", retVal);
			}

			Emit(OpCode.LeaveFunc, String.Empty);
			Emit(OpCode.Return, String.Empty);

			return String.Empty;
		}
	}
}
