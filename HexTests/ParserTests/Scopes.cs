using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
	public class Scopes : ParserTestUtilities
	{
		[Test]
		public void If()
		{
			var list = Parse(Constants.kSimpleIfStatement);
			var child = list.Children.FirstOrDefault();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.IfStatement));

			var ifs = child as IfStatement;
			Assert.That(ifs, Is.Not.Null);
			Assert.That(ifs.Condition, Is.Not.Null);
			Assert.That(ifs.InnerScope, Is.Not.Null);
		}

		[Test]
		public void While()
		{
			var list = Parse(Constants.kSimpleWhileStatement);
			var child = list.Children.FirstOrDefault();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.WhileStatement));

			var ifs = child as WhileStatement;
			Assert.That(ifs, Is.Not.Null);
			Assert.That(ifs.Condition, Is.Not.Null);
			Assert.That(ifs.InnerScope, Is.Not.Null);
		}

		[Test]
		public void For()
		{
			// ⟥ ⇄ ᛖ 0 ⇒ 10 \r\n \r\n ⟤
			var list = Parse(Constants.kSimpleForStatement);
			var child = list.Children.FirstOrDefault();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.ForStatement));

			var frs = child as ForStatement;
			Assert.That(frs, Is.Not.Null);
			Assert.That(frs.From, Is.Not.Null);
			Assert.That(frs.To, Is.Not.Null);
			Assert.That(frs.InnerScope, Is.Not.Null);
		}

		[Test]
		public void IfElse()
		{
			var list = Parse(Constants.kSimpleIfElseStatement);
			var child = list.Children.FirstOrDefault();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.IfStatement));

			var ifs = child as IfStatement;
			Assert.That(ifs, Is.Not.Null);
			Assert.That(ifs.BranchList.Count, Is.EqualTo(1));
			Assert.That(ifs.BranchList[0].Condition.Type, Is.EqualTo(ExpressionTypes.DefaultCondition));
		}

		[Test]
		public void IfElseIf()
		{
			var list = Parse(Constants.kSimpleIfElseIfStatement); 
			var child = list.Children.FirstOrDefault();

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.IfStatement));

			var ifs = child as IfStatement;
			Assert.That(ifs, Is.Not.Null);
			Assert.That(ifs.BranchList.Count, Is.EqualTo(1));
			Assert.That(ifs.BranchList[0].Condition.Type, Is.EqualTo(ExpressionTypes.BinaryOp));
		}
	}
}
