using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class ForStatement : Expression
	{
		public NamedStatement VarName { get; private set; }
		public Expression From { get; private set; }
		public Expression To { get; private set; }
		public Scope InnerScope { get; private set; }

		public ForStatement(NamedStatement named, Expression from, Expression to, Scope inner)
			: base(ExpressionTypes.ForStatement)
		{
			VarName = named;
			From = from;
			To = to;
			InnerScope = inner;
		}
	}
}
