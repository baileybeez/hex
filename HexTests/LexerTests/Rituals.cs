
using Hex.Arcanum.Common;
using Hex.Arcanum.Lexer;

namespace HexTests.LexerTests
{
	public class Rituals
	{
		private Lexer _lexer = new();

		[Test]
		public void Declaration()
		{
			var list = _lexer.Run(Constants.kRitualDeclaration);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(20));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.Ritual));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.RightArrow));
			Assert.That(list[3].Type, Is.EqualTo(LexemeTypes.Ash));

			Assert.That(list[5].Type, Is.EqualTo(LexemeTypes.Conjure));
			Assert.That(list[6].Type, Is.EqualTo(LexemeTypes.Cauldron));

			Assert.That(list[8].Type, Is.EqualTo(LexemeTypes.Place));
			Assert.That(list[9].Type, Is.EqualTo(LexemeTypes.Earth));
			Assert.That(list[10].Type, Is.EqualTo(LexemeTypes.Salt));
			Assert.That(list[11].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[12].Type, Is.EqualTo(LexemeTypes.StirCW));

			Assert.That(list[14].Type, Is.EqualTo(LexemeTypes.Circle));
			Assert.That(list[15].Type, Is.EqualTo(LexemeTypes.OpenScope));

			Assert.That(list[18].Type, Is.EqualTo(LexemeTypes.CloseScope));
			Assert.That(list[19].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void Invokation()
		{
			var list = _lexer.Run(Constants.kRitualInvokation);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(11));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.Conjure));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.Cauldron));

			Assert.That(list[3].Type, Is.EqualTo(LexemeTypes.Place));
			Assert.That(list[4].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[5].Type, Is.EqualTo(LexemeTypes.Cauldron));
			Assert.That(list[6].Type, Is.EqualTo(LexemeTypes.StirCW));

			Assert.That(list[8].Type, Is.EqualTo(LexemeTypes.Invoke));
			Assert.That(list[9].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[10].Type, Is.EqualTo(LexemeTypes.NewLine));
		}

		[Test]
		public void Add_a_b_Declare()
		{
			var list = _lexer.Run(Constants.kRitual_Add);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(30));
			Assert.That(list[0].Type, Is.EqualTo(LexemeTypes.Ritual));
			Assert.That(list[1].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[2].Type, Is.EqualTo(LexemeTypes.RightArrow));
			Assert.That(list[3].Type, Is.EqualTo(LexemeTypes.Salt));

			Assert.That(list[5].Type, Is.EqualTo(LexemeTypes.Conjure));
			Assert.That(list[6].Type, Is.EqualTo(LexemeTypes.Cauldron));

			Assert.That(list[8].Type, Is.EqualTo(LexemeTypes.Place));
			Assert.That(list[9].Type, Is.EqualTo(LexemeTypes.Fire));
			Assert.That(list[10].Type, Is.EqualTo(LexemeTypes.Salt));
			Assert.That(list[11].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[12].Type, Is.EqualTo(LexemeTypes.StirCW));

			Assert.That(list[14].Type, Is.EqualTo(LexemeTypes.Place));
			Assert.That(list[15].Type, Is.EqualTo(LexemeTypes.Fire));
			Assert.That(list[16].Type, Is.EqualTo(LexemeTypes.Salt));
			Assert.That(list[17].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[18].Type, Is.EqualTo(LexemeTypes.StirCW));

			Assert.That(list[20].Type, Is.EqualTo(LexemeTypes.Circle));
			Assert.That(list[21].Type, Is.EqualTo(LexemeTypes.OpenScope));

			Assert.That(list[23].Type, Is.EqualTo(LexemeTypes.Return));
			Assert.That(list[24].Type, Is.EqualTo(LexemeTypes.Identifier));
			Assert.That(list[25].Type, Is.EqualTo(LexemeTypes.Plus));
			Assert.That(list[26].Type, Is.EqualTo(LexemeTypes.Identifier));

			Assert.That(list[28].Type, Is.EqualTo(LexemeTypes.CloseScope));
			Assert.That(list[29].Type, Is.EqualTo(LexemeTypes.NewLine));
		}
	}
}
