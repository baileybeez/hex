using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class DefaultCondition: Expression
	{
		public DefaultCondition() : base(ExpressionTypes.DefaultCondition) { }
	}

	public sealed class IfStatement : Expression
	{
		public Expression Condition { get; private set; }
		public Scope InnerScope { get; private set; }

		private readonly List<IfStatement> _branchList = new();
		public IReadOnlyList<IfStatement> BranchList { get { return _branchList; } }

		public IfStatement(Expression condition, Scope scope)
			: base(ExpressionTypes.IfStatement)
		{
			Condition = condition;
			InnerScope = scope;
		}

		public void PushBranch(Expression condition, Scope scope)
		{
			_branchList.Add(new IfStatement(condition, scope));
		}
	}
}
