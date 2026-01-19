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

			string pfx = "";
			Variable? var = LookupVariable(conj.Name);
			if (var == null)
				throw new HexException($"Variable '{conj.Name}' used prior to being conjured.");

			var mapped = LookupMappedVar(conj.Name);
			if (mapped != null)
				return mapped;

			return conj.Name;
		}
	}
}
