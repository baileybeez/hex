using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerExpression(Expression expr)
		{
			if (_handlerMap.ContainsKey(expr.Type))
				return _handlerMap[expr.Type](expr);

			throw new HexException($"Unsupported expression {expr.Type}");
		}
	}
}
