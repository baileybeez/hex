using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
	public class Conjure : ParserTestUtilities
	{
		[Test]
		public void ConjureVar()
		{
			var ret = Parse(Constants.kConjureVar);
			var child = ret.Children.First() as VariableConjuration;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Name, Is.EqualTo(Constants.kVarName));
			Assert.That(child.Flag, Is.EqualTo(VariableFlags.Volitile));
			Assert.That(child.ValueType, Is.EqualTo(VariableTypes.U64));
			Assert.That(child.InitialValue, Is.Null);
		}

		[Test]
		public void ConjureVarWithValue()
		{
			var ret = Parse(Constants.kConjureVarAssign);
			var child = ret.Children.First() as VariableConjuration;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Name, Is.EqualTo(Constants.kVarName));
			Assert.That(child.ValueType, Is.EqualTo(VariableTypes.U64));
			Assert.That(child.Flag, Is.EqualTo(VariableFlags.Constant));
			Assert.That(child.InitialValue, Is.Not.Null);
			Assert.That(child.InitialValue.Type, Is.EqualTo(ExpressionTypes.NumberLiteral));
		}

		[Test]
		public void PointerConjure()
		{
			Assert.Ignore();
		}

		[Test]
		public void CharConjure()
		{
			var ret = Parse(Constants.kConjureChar);
			var conj = ret.Children.First() as VariableConjuration;

			Assert.That(conj, Is.Not.Null);
			Assert.That(conj.Name, Is.EqualTo(Constants.kVarName));
			Assert.That(conj.ValueType, Is.EqualTo(VariableTypes.Char));
			Assert.That(conj.Flag, Is.EqualTo(VariableFlags.Volitile));
			Assert.That(conj.InitialValue, Is.Not.Null);
			Assert.That(conj.InitialValue.Type, Is.EqualTo(ExpressionTypes.CharLiteral));
		}

		[Test]
		public void StringConjure()
		{
			var ret = Parse(Constants.kConjureString);
			var conj = ret.Children.First() as VariableConjuration;

			Assert.That(conj, Is.Not.Null);
			Assert.That(conj.Name, Is.EqualTo(Constants.kVarName));
			Assert.That(conj.ValueType, Is.EqualTo(VariableTypes.String));
			Assert.That(conj.Flag, Is.EqualTo(VariableFlags.Volitile));
			Assert.That(conj.InitialValue, Is.Not.Null);
			Assert.That(conj.InitialValue.Type, Is.EqualTo(ExpressionTypes.StringLiteral));
		}
	}
}
