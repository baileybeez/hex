
using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
	public sealed class Assignment : ParserTestUtilities
	{
		[Test]
		public void U64Assignment()
		{
			var scope = Parse(Constants.kAssignmentScript);
			var conj = scope.Children.ElementAt(0) as VariableConjuration;
			var assign = scope.Children.ElementAt(1) as AssignmentStatement;

			Assert.That(assign, Is.Not.Null);
			Assert.That(assign.VarName, Is.EqualTo(Constants.kVarName));
			Assert.That(assign.ValueExpression, Is.Not.Null);
			Assert.That(assign.ValueExpression.Type, Is.EqualTo(ExpressionTypes.NumberLiteral));
		}
	}
}
