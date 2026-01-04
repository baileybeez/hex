using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		private readonly Dictionary<string, object> _memory = new();

		public void SetValue(string key, object val)
		{
			_memory[key] = val;
		}

		public bool TryGetValue(string key, out object val)
		{
			return _memory.TryGetValue(key, out val);
		}

		public object GetValue(string key)
		{
			if (!_memory.ContainsKey(key))
				throw new HexException($"Variable '{key}' is not defined!");

			return _memory[key];
		}
	}
}
