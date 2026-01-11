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

			var mapped = LookupVar(conj.Name);
			if (mapped != null)
				return mapped;

			return conj.Name;
		}
	}
}
