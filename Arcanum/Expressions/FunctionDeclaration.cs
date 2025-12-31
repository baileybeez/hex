using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Expressions
{
	public sealed class FunctionDeclaration : Expression
	{
		public string FunctionName { get; private set; }
		public VariableTypes ReturnType { get; private set; }
		public Scope FunctionScope { get; private set; }
		public bool IsEntryPoint { get; private set; }

		private readonly List<FunctionParam> _paramList = new();

		public FunctionDeclaration(string identifier, VariableTypes retType, List<FunctionParam> paramList, Scope fncScope, bool entryPoint)
			: base(ExpressionTypes.FunctionDeclaration)
		{
			FunctionName = identifier;
			ReturnType = retType;
			_paramList.AddRange(paramList);
			FunctionScope = fncScope;
			IsEntryPoint = entryPoint;
		}

		public IReadOnlyList<FunctionParam> Parameters { get { return _paramList; } }
	}
}
