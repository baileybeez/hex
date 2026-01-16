
using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class AssignmentStatement : Expression
	{
		public string VarName { get; private set; }
		public VariableTypes VarType { get; private set; }
		public Expression ValueExpression { get; private set; }

		public AssignmentStatement(string name, VariableTypes varType, Expression value)
			: base(Common.ExpressionTypes.Assignment)
		{
			VarName = name;
			VarType = varType;
			ValueExpression = value;
		}
	}
}
