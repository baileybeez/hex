using Hex.Arcanum.Common;
using Hex.Arcanum.Lexer;

namespace HexTests.LexerTests
{
    public class Variables
    {
		private Lexer _lexer;

		[SetUp]
		public void Setup()
		{
			_lexer = new Lexer();
		}

		[Test]
		public void VarDeclaration()
		{
			var decl = _lexer.Run(Constants.kConjureVar);
			Assert.That(decl.Count, Is.EqualTo(5));
			Assert.That(decl[0].Type, Is.EqualTo(LexemeTypes.Conjure));
			Assert.That(decl[1].Type, Is.EqualTo(LexemeTypes.Fire));
			Assert.That(decl[2].Type, Is.EqualTo(LexemeTypes.Salt));
			Assert.That(decl[3].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(decl[3].Text, Is.EqualTo("ᚫ"));
			Assert.That(decl[4].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void VarDeclWithAssignment()
		{
			var decl = _lexer.Run(Constants.kConjureVarAssign);
			Assert.That(decl.Count, Is.EqualTo(7));
			Assert.That(decl[0].Type, Is.EqualTo(LexemeTypes.Conjure));
			Assert.That(decl[1].Type, Is.EqualTo(LexemeTypes.Earth));
			Assert.That(decl[2].Type, Is.EqualTo(LexemeTypes.Salt));
			Assert.That(decl[3].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(decl[3].Text, Is.EqualTo("ᚫ"));
			Assert.That(decl[4].Type, Is.EqualTo(LexemeTypes.LeftArrow));
			Assert.That(decl[5].Type, Is.EqualTo(LexemeTypes.Number));
			Assert.That(decl[5].Text, Is.EqualTo("1"));
			Assert.That(decl[6].Type, Is.EqualTo(LexemeTypes.NewLine));
		}
	}
}
