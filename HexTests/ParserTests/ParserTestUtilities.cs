using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;
using System.Text;

namespace HexTests.ParserTests
{
	public class ParserTestUtilities
	{
		Lexer _lexer = new();

		public Scope Parse(string str)
		{
			var tokens = _lexer.Run(str);
			var parser = new Parser();

			return parser.Run(tokens);
		}

		public void AssertUnaryIs(Expression expr, UnaryOperatorTypes unOp)
		{
			var unExpr = expr as UnaryOperation;
			Assert.That(unExpr, Is.Not.Null);
			Assert.That(unExpr.Operator, Is.EqualTo(unOp));
		}

		public void AssertBinaryIs(Expression expr, BinaryOperatorTypes binOp)
		{
			var binExpr = expr as BinaryOperation;
			Assert.That(binExpr, Is.Not.Null);
			Assert.That(binExpr.Operator, Is.EqualTo(binOp));
			Assert.That(binExpr.Left, Is.Not.Null);
			Assert.That(binExpr.Left.Type, Is.EqualTo(ExpressionTypes.NumberLiteral));
			Assert.That(binExpr.Right, Is.Not.Null);
			Assert.That(binExpr.Right.Type, Is.EqualTo(ExpressionTypes.NumberLiteral));
		}
	}
}
