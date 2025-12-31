using Hex.Arcanum.Common;
using Hex.Arcanum.Lexer;

namespace HexTests.LexerTests
{
	public class Arithmetic
	{
		private Lexer _lexer;

		[SetUp]
		public void Setup()
		{
			_lexer = new Lexer();
		}

		[Test]
		public void SimpleParse()
		{
			string str = "1 + 2";
			var list = _lexer.Run(str);

			Assert.That(list.Count, Is.EqualTo(4));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(list[0].Text, Is.EqualTo("1"));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.Plus));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(list[2].Text, Is.EqualTo("2"));
			Assert.That(list[3].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void Maths()
		{
			char[] parts = { '(', '1', '+', '2', ')', '*', '3' };
			string line = String.Join(" ", parts);
			var list = _lexer.Run(line);

			Assert.That(list.Count, Is.EqualTo(8));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.OpenParen));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(list[1].Text, Is.EqualTo("1"));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.Plus));
			Assert.That(list[3].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(list[3].Text, Is.EqualTo("2"));
			Assert.That(list[4].Type, Is.EqualTo(LexemeTypes.CloseParen));
			Assert.That(list[5].Type, Is.EqualTo(LexemeTypes.Times));
			Assert.That(list[6].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(list[6].Text, Is.EqualTo("3"));
			Assert.That(list[7].Type, Is.EqualTo(LexemeTypes.NewLine));
		}
	}
}
