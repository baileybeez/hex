
using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
	public class Unary : ParserTestUtilities
	{
		[Test]
		public void Amplify()
		{
			var scope = Parse(Constants.kAmp);
			var child = scope.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.UnaryOp));
			AssertUnaryIs(child, UnaryOperatorTypes.Amplify);
		}

		[Test]
		public void Diminish()
		{
			var scope = Parse(Constants.kDim);
			var child = scope.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.UnaryOp));
			AssertUnaryIs(child, UnaryOperatorTypes.Diminish);
		}
	}
}
