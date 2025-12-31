using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class VariableConjuration : Expression
	{
		public string Name { get; private set; }
		public VariableTypes ValueType { get; private set; }
		public VariableFlags Flag { get; private set; }
		public Expression? InitialValue { get; private set; }

		public VariableConjuration(string varName, VariableTypes varType, VariableFlags varFlag, Expression? valExpr)
			: base(ExpressionTypes.VariableConjuration)
		{
			Name = varName;
			ValueType = varType;
			Flag = varFlag;
			InitialValue = valExpr;
		}
	}
}
