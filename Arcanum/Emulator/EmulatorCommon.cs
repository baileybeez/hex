using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public string GetString(object val)
		{
			return Convert.ToString(val);
		}

		public char GetChar(object val)
		{
			return Convert.ToChar(val);
		}

		public bool GetBool(object val)
		{
			return Convert.ToBoolean(val);
		}

		public UInt64 GetU64(object val)
		{
			return Convert.ToUInt64(val);
		}
	}
}
