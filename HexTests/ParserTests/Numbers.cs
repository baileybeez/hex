using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace HexTests.ParserTests
{
	public class Numbers : ParserTestUtilities
	{
		[Test]
		public void NumberLiteral()
		{
			const int value = 15;
			string src = $"{value}";
			var ret = Parse(src);
			var child = ret.Children.First();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.NumberLiteral));

			var lit = child as U64Literal;
			Assert.That(lit, Is.Not.Null);
			Assert.That(lit.Value, Is.EqualTo(value));
		}
	}
}
