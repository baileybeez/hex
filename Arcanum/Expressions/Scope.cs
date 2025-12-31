using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public enum ScopeTypes
	{
		Unknown = 0,
		Global = 1,
		Function = 2,
		EntryPoint = 3,
		Local = 4
	}

	public sealed class Scope : Expression
	{
		private readonly Scope? _parent;
		public ScopeTypes ScopeType { get; private set; }
		private readonly List<Expression> _exprList = new();
		private readonly Dictionary<string, Variable> _varMap = new();

		public Scope(Scope? parent, ScopeTypes type)
			: base(ExpressionTypes.Scope)
		{
			_parent = parent;
			ScopeType = type;
		}

		public FunctionDeclaration? FindEntryPoint()
		{
			if (ScopeType != ScopeTypes.Global)
				return null;

			var fncList = this.Children.Where(c => c.Type == ExpressionTypes.FunctionDeclaration).Select(c => c as FunctionDeclaration);

			return fncList.FirstOrDefault(fnc => fnc?.IsEntryPoint == true);
		}

		public uint CalculateLocalSize()
		{
			if (ScopeType != ScopeTypes.Function)
				return 0;

			uint size = 0;
			var declareList = _exprList.Where(a => a.Type == ExpressionTypes.VariableConjuration);
			foreach (var decl in declareList)
			{
				// TODO: determine sizeof for vartype
				size += 8;
			}

			return size;
		}

		public void AddExpression(Expression expr)
		{
			_exprList.Add(expr);
		}

		public Variable AddVariable(string varName, VariableTypes varType, VariableFlags varFlag)
		{
			if (!_varMap.ContainsKey(varName))
				_varMap.Add(varName, new Variable(varName, varType, varFlag));

			return _varMap[varName];
		}

		public Variable? LookupVariable(string identifier)
		{
			if (_varMap.TryGetValue(identifier, out var variable))
				return variable;

			return null;
		}

		public IReadOnlyCollection<Expression> Children => _exprList;
	}
}
