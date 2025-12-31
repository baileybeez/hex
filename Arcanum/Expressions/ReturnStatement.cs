using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public sealed class ReturnStatement : Expression
	{
		public Expression Expression { get; private set; }

		public ReturnStatement(Expression right)
			: base(ExpressionTypes.Return)
		{
			Expression = right;
		}
	}
}
