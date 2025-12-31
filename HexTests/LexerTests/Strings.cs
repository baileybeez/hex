using Hex.Arcanum.Common;
using Hex.Arcanum.Lexer;

namespace HexTests.LexerTests
{
	public class Strings
	{
		private Lexer _lexer = new Lexer();
			
		[Test]
		public void LexString()
		{
			var list = _lexer.Run(Constants.kConsoleOutput);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(3));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.Whisper));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.String));
			Assert.That(list[1].Text, Is.EqualTo("hello world"));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void StringWithCRLF()
		{
			var list = _lexer.Run(Constants.kStringWithCRLF);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(3));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.String));
			Assert.That(list[1].Text, Is.EqualTo("1\n"));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test] 
		public void SplitIntoLines()
		{
			string src = "this is \r\n several lines of text \r\n and a \"quoted \n string\"";
			var list = _lexer.SplitIntoLines(src);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Length, Is.EqualTo(3));
			Assert.That(list[0], Is.EqualTo("this is "));
			Assert.That(list[1], Is.EqualTo(" several lines of text "));
			Assert.That(list[2], Is.EqualTo(" and a \"quoted \n string\""));
		}
	}
}
