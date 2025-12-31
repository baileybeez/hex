using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerNamedType(Expression expr)
		{
			var conj = AssertValid<NamedStatement>(expr);
			if (_paramMap.ContainsKey(conj.Name))
				return _paramMap[conj.Name];

			return conj.Name;
		}
	}
}
