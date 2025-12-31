using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
    public class Arithmetic : ParserTestUtilities
	{

		[Test]
		public void Addition()
		{
			var ret = Parse("1 + 2");
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
			AssertBinaryIs(child, BinaryOperatorTypes.Addition);
		}

		[Test]
		public void Subtraction()
		{
			var ret = Parse("1 - 2");
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
			AssertBinaryIs(child, BinaryOperatorTypes.Subtraction);
		}


		[Test]
		public void Multiplication()
		{
			var ret = Parse("1 * 2");
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
			AssertBinaryIs(child, BinaryOperatorTypes.Multiplication);
		}


		[Test]
		public void Division()
		{
			var ret = Parse("1 / 2");
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
			AssertBinaryIs(child, BinaryOperatorTypes.Division);
		}
	}
}
