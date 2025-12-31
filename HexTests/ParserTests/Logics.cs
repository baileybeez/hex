using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
	public class Logics : ParserTestUtilities
	{
		[Test]
		public void Equality()
		{
			var ret = Parse(Constants.kEqualityScript);
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
			AssertBinaryIs(child, BinaryOperatorTypes.Equality);
		}

		[Test]
		public void Invert()
		{
			var ret = Parse(Constants.kBangScript);
			var child = ret.Children.First() as UnaryOperation;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.UnaryOp));
			Assert.That(child.Operator, Is.EqualTo(UnaryOperatorTypes.Invert));
			Assert.That(child.Right, Is.Not.Null);
			Assert.That(child.Right.Type, Is.EqualTo(ExpressionTypes.BooleanLiteral));
		}

		[Test]
		public void BadUnary()
		{
			try
			{
				var ret = Parse("!");
			}
			catch (HexException)
			{
				Assert.Pass();
			}
		}
	}
}
