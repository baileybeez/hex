using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		private readonly Registers _regs = new();

		public void SetValue(string key, object val)
		{
			int idx = Registers.RegKeys.IndexOf(key);
			if (idx != -1)
				_regs.Set(idx, Convert.ToInt64(val));

			_memory[key] = val;
		}

		public bool TryGetValue(string key, out object val)
		{
			return _memory.TryGetValue(key, out val);
		}

		public object GetValue(string key)
		{
			int idx = Registers.RegKeys.IndexOf(key);
			if (idx != -1)
				return _regs.Get(idx);

			if (!_memory.ContainsKey(key))
				throw new HexException($"Variable '{key}' is not defined!");

			return _memory[key];
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
