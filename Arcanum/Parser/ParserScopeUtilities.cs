using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		public void ValidateUnusedIdentifier(string identifier)
		{
			var obj = _scopeStack.Peek().LookupVariable(identifier);
			if (obj != null)
				throw new IdentifierReusedException(identifier, "variable");
		}

		public Variable AddVar(string identifier, VariableTypes type, VariableFlags flag)
		{
			return _scopeStack.Peek().AddVariable(identifier, type, flag);
		}

		public Variable? LookupVar(string identifier)
		{
			return _scopeStack.Peek().LookupVariable(identifier);
		}

		public Scope CreateScope(ScopeTypes scopeType)
		{
			var scope = new Scope(_scopeStack.Peek(), scopeType);
			_scopeStack.Push(scope);
			return scope;
		}

		public void PopScope() {  _scopeStack.Pop(); }
	}
}