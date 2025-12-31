
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Common
{
	public sealed class InvokationParam
	{
		public Expression Param { get; private set; }
		public StirDirection Stir { get; private set; }

		public InvokationParam(Expression expr, StirDirection stir) 
		{ 
			Param = expr;
			Stir = stir;
		}
	}
}
