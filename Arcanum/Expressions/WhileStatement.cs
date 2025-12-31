using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class WhileStatement : Expression
	{
		public Expression Condition { get; private set; }
		public Scope InnerScope { get; private set; }

		public WhileStatement(Expression condition, Scope innerScope)
			: base(ExpressionTypes.WhileStatement)
		{
			Condition = condition;
			InnerScope = innerScope;
		}
	}
}
