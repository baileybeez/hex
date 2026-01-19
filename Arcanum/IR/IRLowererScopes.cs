using Hex.Arcanum.Common;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		private readonly Stack<IRScope> _scopeStack = new();

		public IRScope PushScope()
		{
			IRScope? p = _scopeStack.Count == 0 ? null : _scopeStack.Peek();
			IRScope scope = new(p);

			_scopeStack.Push(scope);
			return scope;
		}

		public void PopScope() { _scopeStack.Pop(); }

		public Variable AddVariable(string varName, VariableTypes varType, VariableFlags varFlag)
		{
			return _scopeStack.Peek().AddVariable(varName, varType, varFlag);
		}

		public Variable? LookupVariable(string varName)
		{
			return _scopeStack.Peek().LookupVariable(varName);
		}

		public void AddMappedVar(string varName, string tempName)
		{
			_scopeStack.Peek().AddMappedVar(varName, tempName);
		}

		public string? LookupMappedVar(string varName)
		{
			if (_scopeStack.Count == 0) 
				return null;

			return _scopeStack.Peek().LookupMappedVar(varName);
		}
	}
}