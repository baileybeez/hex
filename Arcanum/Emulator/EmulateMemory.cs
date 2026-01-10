using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		private readonly Dictionary<string, object> _memory = new();

		public int GetUsedMemoryCount()
		{
			return _memory.Count; 
		}

		public void SetValue(string key, object val)
		{
			if (RegisterUtils.IsReg(key))
				SetRegister(key, Convert.ToUInt64(val));
			else 
				_memory[key] = val;
		}

		public bool TryGetValue(string key, out object val)
		{
			val = 0;
			if (RegisterUtils.IsReg(key))
			{
				val = GetRegister(key);
				return true;
			}
			else if (_memory.ContainsKey(key))
			{
				val = _memory[key];
				return true;
			}
			 
			return false;
		}

		public object GetValue(string key)
		{
			if (RegisterUtils.IsReg(key))
				return GetRegister(key);

			if (!_memory.ContainsKey(key))
				throw new HexException($"Variable '{key}' is not defined!");

			return _memory[key];
		}
	}
}
