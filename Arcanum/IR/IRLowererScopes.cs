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

		public void AddVar(string varName, string tempName)
		{
			_scopeStack.Peek().Add(varName, tempName);
		}

		public string? LookupVar(string varName)
		{
			if (_scopeStack.Count == 0) 
				return null;

			return _scopeStack.Peek().Lookup(varName);
		}
	}
}