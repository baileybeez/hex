using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		private readonly Dictionary<Registers, UInt64> _regs = new();

		public void SetRegister(string regName, UInt64 val)
		{
			if (!RegisterUtils.TryGet(regName, out Registers reg))
				throw new HexException($"Regsiter '{regName}' is not defined!");

			_regs[reg] = val;
		}

		public UInt64 GetRegister(string regName)
		{
			if (!RegisterUtils.TryGet(regName, out Registers reg))
				throw new HexException($"Regsiter '{regName}' is not defined!");

			return _regs[reg];
		}
	}
}
