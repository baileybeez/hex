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
			var retVal = LowerExpression(ret.Expression);
			Emit(OpCode.Return, String.Empty, retVal);

			return String.Empty;
		}
	}
}
