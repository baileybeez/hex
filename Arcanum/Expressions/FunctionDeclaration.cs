using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Expressions
{
	public sealed class FunctionDeclaration : Expression
	{
		public string FunctionName { get; private set; }
		public Variable ReturnClass { get; private set; }
		public Scope FunctionScope { get; private set; }
		public bool IsEntryPoint { get; private set; }

		private readonly List<FunctionParam> _paramList = new();

		public FunctionDeclaration(string identifier, VariableTypes retType, List<FunctionParam> paramList, Scope fncScope, bool entryPoint)
			: base(ExpressionTypes.FunctionDeclaration)
		{
			FunctionName = identifier;
			ReturnClass = new Variable("retvar", retType, VariableFlags.Volitile);
			FunctionScope = fncScope;
			IsEntryPoint = entryPoint;

			_paramList.AddRange(paramList);
			ProcessParamInformation();
		}

		public IReadOnlyList<FunctionParam> Parameters { get { return _paramList; } }

		public void ProcessParamInformation()
		{
			for (int idx = _paramList.Count - 1; idx >= 0; idx--)
			{
				if (idx < 6)
				{
					_paramList[idx].Location = RegisterUtils.GetByArg(idx); 
				}
				else
				{ 
					int stackOffset = RegisterUtils.GetOffset(idx);
					_paramList[idx].Location = stackOffset.ToString();
				}
			}
		}
	}
}
