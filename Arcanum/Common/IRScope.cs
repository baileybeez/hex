
namespace Hex.Arcanum.Common
{
	public sealed class IRScope
	{
		private readonly Dictionary<string, string> _varNameMap = new();
		private readonly IRScope? _parent;

		public IRScope(IRScope? parent)
		{
			_parent = parent;
		}

		public void Add(string varName, string tempName)
		{
			_varNameMap.Add(varName, tempName);
		}

		public string? Lookup(string varName)
		{
			if (_varNameMap.TryGetValue(varName, out var str))
				return str;

			if (_parent != null)
				return _parent.Lookup(varName);

			return null;
		}
	}
}
