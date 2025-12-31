
namespace Hex.Arcanum.Exceptions
{
	public sealed class IdentifierReusedException : HexException
	{
		public IdentifierReusedException(string ident, string usedAs)
			: base($"Identifier '{ident}' is already in use as a {usedAs}.")
		{

		}
	}
}
