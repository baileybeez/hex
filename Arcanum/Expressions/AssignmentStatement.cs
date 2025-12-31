
namespace Hex.Arcanum.Expressions
{
	public sealed class AssignmentStatement : Expression
	{
		public string VarName { get; private set; }
		public Expression ValueExpression { get; private set; }

		public AssignmentStatement(string name, Expression value)
			: base(Common.ExpressionTypes.Assignment)
		{
			VarName = name;
			ValueExpression = value;
		}
	}
}
