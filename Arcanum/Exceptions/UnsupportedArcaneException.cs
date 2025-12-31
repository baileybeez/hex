using System.Text;

namespace Hex.Arcanum.Exceptions
{
	public sealed class UnsupportedArcaneException : HexException
	{
		public UnsupportedArcaneException(Rune rune, int lineNo, int col)
			: base($"Unsupported arcane symbol '{rune}' at line {lineNo}, col {col}.")
		{
		}
	}
}
