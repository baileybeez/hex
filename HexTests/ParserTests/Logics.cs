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
		public void AndEquality()
		{
			var ret = Parse(Constants.kAndEqualityScript);
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.BinaryOp));

			var binExpr = child as BinaryOperation;
			Assert.That(binExpr, Is.Not.Null);
			Assert.That(binExpr.Operator, Is.EqualTo(BinaryOperatorTypes.And));
			Assert.That(binExpr.Left.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
			Assert.That(binExpr.Right.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
		}

		[Test]
		public void OrEquality()
		{
			var ret = Parse(Constants.kOrEqualityScript);
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.BinaryOp));

			var binExpr = child as BinaryOperation;
			Assert.That(binExpr, Is.Not.Null);
			Assert.That(binExpr.Operator, Is.EqualTo(BinaryOperatorTypes.Or));
			Assert.That(binExpr.Left.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
			Assert.That(binExpr.Right.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
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
