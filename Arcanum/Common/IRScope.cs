
namespace Hex.Arcanum.Common
{
	public sealed class IRScope
	{
		private readonly Dictionary<string, string> _varNameMap = new();
		private readonly Dictionary<string, Variable> _varMap = new();
		private readonly IRScope? _parent;

		public IRScope(IRScope? parent)
		{
			_parent = parent;
		}

		public Variable AddVariable(string varName, VariableTypes varType, VariableFlags varFlag)
		{
			Variable var = new Variable(varName, varType, varFlag);

			_varMap.Add(varName, var);
			return var;
		}

		public Variable? LookupVariable(string varName)
		{
			if (_varMap.ContainsKey(varName)) 
				return _varMap[varName];

			if (_parent != null)
				return _parent.LookupVariable(varName);

			return null;
		}

		public void AddMappedVar(string varName, string tempName)
		{
			_varNameMap.Add(varName, tempName);
		}

		public string? LookupMappedVar(string varName)
		{
			if (_varNameMap.TryGetValue(varName, out var str))
				return str;

			if (_parent != null)
				return _parent.LookupMappedVar(varName);

			return null;
		}
	}
}
