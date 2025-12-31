
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
			var child = scope.Children.FirstOrDefault() as AssignmentStatement;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.VarName, Is.EqualTo(Constants.kVarName));
			Assert.That(child.ValueExpression, Is.Not.Null);
			Assert.That(child.ValueExpression.Type, Is.EqualTo(ExpressionTypes.NumberLiteral));
		}
	}
}
