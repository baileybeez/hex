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

		[Test]
		public void PointerVar()
		{
			var ptr = _lexer.Run(Constants.kConjurePointer);

			Assert.That(ptr.Count, Is.EqualTo(8));
			Assert.That(ptr[0].Type, Is.EqualTo(LexemeTypes.Conjure));
			Assert.That(ptr[1].Type, Is.EqualTo(LexemeTypes.Aether));
			Assert.That(ptr[2].Type, Is.EqualTo(LexemeTypes.Salt));
			Assert.That(ptr[3].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(ptr[3].Text, Is.EqualTo("ᚫ"));
			Assert.That(ptr[4].Type, Is.EqualTo(LexemeTypes.LeftArrow));
			Assert.That(ptr[5].Type, Is.EqualTo(LexemeTypes.Anchor));
			Assert.That(ptr[6].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(ptr[6].Text, Is.EqualTo("ᛖ"));
			Assert.That(ptr[7].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void CharVar()
		{
			string ans = "A";
			var truth = new LexemeTypes[] {
				LexemeTypes.Conjure,
				LexemeTypes.Fire,
				LexemeTypes.Sulfur,
				LexemeTypes.Identifier,
				LexemeTypes.LeftArrow,
				LexemeTypes.Char,
				LexemeTypes.NewLine,
			};
			var list = _lexer.Run(Constants.kConjureChar);

			Assert.That(list.Count, Is.EqualTo(truth.Length));
			for (int idx = 0; idx < truth.Length; idx++)
				Assert.That(list[idx].Type, Is.EqualTo(truth[idx]));

			Assert.That(list[3].Text, Is.EqualTo("ᚫ"));
			Assert.That(list[5].Text, Is.EqualTo(ans));
		}

		[Test]
		public void StringVar()
		{
			string ans = "hello world";
			var truth = new LexemeTypes[] {
				LexemeTypes.Conjure,
				LexemeTypes.Fire,
				LexemeTypes.Brimstone,
				LexemeTypes.Identifier,
				LexemeTypes.LeftArrow,
				LexemeTypes.String,
				LexemeTypes.NewLine,
			};
			var list = _lexer.Run(Constants.kConjureString);

			Assert.That(list.Count, Is.EqualTo(truth.Length));
			for (int idx = 0; idx < truth.Length; idx++)
				Assert.That(list[idx].Type, Is.EqualTo(truth[idx]));

			Assert.That(list[3].Text, Is.EqualTo("ᚫ"));
			Assert.That(list[5].Text, Is.EqualTo(ans));
		}
	}
}
