
using Hex.Arcanum.Common;
using Hex.Arcanum.Lexer;

namespace HexTests.LexerTests
{
	public class Scopes
	{
		private Lexer _lexer;

		[SetUp]
		public void Setup()
		{
			_lexer = new Lexer();
		}

		[Test]
		public void IfStatement()
		{
			var list = _lexer.Run(Constants.kSimpleIfStatement);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(9));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.OpenScope));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.If));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[3].Type, Is.EqualTo(LexemeTypes.GreaterThan));
			Assert.That(list[4].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(list[5].Type, Is.EqualTo(LexemeTypes.NewLine));
			Assert.That(list[6].Type, Is.EqualTo(LexemeTypes.NewLine));
			Assert.That(list[7].Type, Is.EqualTo(LexemeTypes.CloseScope));
			Assert.That(list[8].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void WhileStatement()
		{
			var list = _lexer.Run(Constants.kSimpleWhileStatement);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(9));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.OpenScope));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.While));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[3].Type, Is.EqualTo(LexemeTypes.GreaterThan));
			Assert.That(list[4].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(list[5].Type, Is.EqualTo(LexemeTypes.NewLine));
			Assert.That(list[6].Type, Is.EqualTo(LexemeTypes.NewLine));
			Assert.That(list[7].Type, Is.EqualTo(LexemeTypes.CloseScope));
			Assert.That(list[8].Type, Is.EqualTo(LexemeTypes.NewLine));
		}


		[Test]
		public void WeaveStatement()
		{
			var list = _lexer.Run(Constants.kSimpleForStatement);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(10));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.OpenScope));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.Weave));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.Identifier));
			// From
			Assert.That(list[4].Type, Is.EqualTo(LexemeTypes.To));
			// To
			Assert.That(list[6].Type, Is.EqualTo(LexemeTypes.NewLine));
			Assert.That(list[7].Type, Is.EqualTo(LexemeTypes.NewLine));
			Assert.That(list[8].Type, Is.EqualTo(LexemeTypes.CloseScope));
			Assert.That(list[9].Type, Is.EqualTo(LexemeTypes.NewLine));
		}
	}
}
