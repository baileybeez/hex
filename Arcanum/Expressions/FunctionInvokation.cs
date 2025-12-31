using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class FunctionInvokation : Expression
	{
		public string FunctionName { get; private set; }
		public List<InvokationParam> ParameterList { get; private set; } = new();
		public string RetVar { get; private set; }

		public FunctionInvokation(string fncName, List<InvokationParam> paramList, string retVar = "")
			: base(ExpressionTypes.FunctionInvokation)
		{
			FunctionName = fncName;
			ParameterList = paramList;
			RetVar = retVar;
		}
	}
}
