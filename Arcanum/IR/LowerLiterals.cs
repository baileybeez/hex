using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerNumberLiteral(Expression expr)
		{
			var lit = AssertValid<U64Literal>(expr);

			string temp = NewTemp();
			Emit(OpCode.LoadU64Const, temp, lit.Value.ToString());
			return temp;
		}

		public string LowerStringLiteral(Expression expr)
		{
			var lit = AssertValid<StringLiteral>(expr);
			// TODO: push this into resources and emit an address instead
			return lit.Value;
		}
	}
}
