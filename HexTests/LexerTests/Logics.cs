using Hex.Arcanum.Common;
using Hex.Arcanum.Lexer;

namespace HexTests.LexerTests
{
	public class Logics
	{
		private Lexer _lexer;

		[SetUp]
		public void Setup()
		{
			_lexer = new Lexer();
		}

		[Test]
		public void SimpleLogic()
		{
			var truth = _lexer.Run($"!{(char)0x22A4}");
			Assert.That(truth.Count, Is.EqualTo(3));
			Assert.That(truth[0].Type, Is.EqualTo(LexemeTypes.Bang));
			Assert.That(truth[1].Type, Is.EqualTo(LexemeTypes.True));
			Assert.That(truth[2].Type, Is.EqualTo(LexemeTypes.NewLine));

			var falicy = _lexer.Run("⊥");
			Assert.That(falicy.Count, Is.EqualTo(2));
			Assert.That(falicy[0].Type, Is.EqualTo(LexemeTypes.False));
			Assert.That(falicy[1].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void Equality()
		{
			List<Lexeme> lexList = _lexer.Run(Constants.kEqualityScript);
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.Equality));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));

			lexList = _lexer.Run(Constants.kInequalityScript);
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.Inequality));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void GreaterThans()
		{
			List<Lexeme> lexList = _lexer.Run($"1 > 2");
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.GreaterThan));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));

			lexList = _lexer.Run($"1 ≥ 2");
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.GreaterThanEquals));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void LessThans()
		{
			List<Lexeme> lexList = _lexer.Run($"1 < 2");
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.LessThan));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));

			lexList = _lexer.Run($"1 ≤ 2");
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.LessThanEquals));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void LogicalAnd()
		{
			List<Lexeme> lexList = _lexer.Run($"1 ⋏ 2");
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.LogicalAnd));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void LogicalOr()
		{
			List<Lexeme> lexList = _lexer.Run($"1 ⋎ 2");
			Assert.That(lexList.Count, Is.EqualTo(4));
			Assert.That(lexList[0].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[1].Type, Is.EqualTo(LexemeTypes.LogicalOr));
			Assert.That(lexList[2].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(lexList[3].Type, Is.EqualTo(LexemeTypes.NewLine));
		}
	}
}
