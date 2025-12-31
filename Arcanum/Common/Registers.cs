
namespace Hex.Arcanum.Common
{
	public sealed class Registers
	{
		public static readonly string[] RegKeys =
		{
			"RAX", "RBX", "RCX", "RDX",
			"RSI", "RDI", "RSP", "RBP",
			"R8", "R9", "R10", "R11",
			"R12", "R13", "R14", "R15"
		};

		private Int64[] _values = new Int64[RegKeys.Length];

		public Int64 Get(int idx)
		{
			if (idx < 0 || idx >= RegKeys.Length)
				throw new IndexOutOfRangeException();

			return _values[idx];
		}

		public void Set(int idx, Int64 val)
		{
			if (idx < 0 || idx >= RegKeys.Length)
				throw new IndexOutOfRangeException();

			_values[idx] = val;
		}
	}
}
