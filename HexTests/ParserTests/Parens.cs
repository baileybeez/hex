using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
	public class Parens : ParserTestUtilities
	{
		[Test]
		public void ParenTest()
		{
			var list = Parse(Constants.kParenScript);
			var child = list.Children.FirstOrDefault() as BinaryOperation;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Left.Type, Is.EqualTo(ExpressionTypes.Parenthesized));
			Assert.That(child.Operator, Is.EqualTo(BinaryOperatorTypes.Multiplication));
			Assert.That(child.Right.Type, Is.EqualTo(ExpressionTypes.NumberLiteral));
		}
	}
}
