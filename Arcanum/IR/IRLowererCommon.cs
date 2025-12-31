using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public T AssertValid<T>(Expression? expr) where T : class
		{
			if (expr is T result)
				return result;
			
			throw new HexException("Invalid object for this lower operation");
		}
	}
}
