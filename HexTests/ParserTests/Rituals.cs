using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.Lexer;

namespace HexTests.ParserTests
{
	public class Rituals : ParserTestUtilities
	{
		[Test]
		public void Declaration()
		{
			var scope = Parse(Constants.kRitualDeclaration);
			var child = scope.Children.FirstOrDefault() as FunctionDeclaration;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.FunctionName, Is.EqualTo("ᚠᛇᛒ"));
			Assert.That(child.ReturnClass.Type, Is.EqualTo(VariableTypes.Void));
			Assert.That(child.Parameters.Count, Is.EqualTo(1));
			Assert.That(child.Parameters[0].Name, Is.EqualTo("ᚷᛖᚾ"));
			Assert.That(child.Parameters[0].Type, Is.EqualTo(VariableTypes.U64));
			Assert.That(child.Parameters[0].Flag, Is.EqualTo(VariableFlags.Constant));
			Assert.That(child.Parameters[0].Stir, Is.EqualTo(StirDirection.Clockwise));
			Assert.That(child.FunctionScope, Is.Not.Null);
		}

		[Test]
		public void Invokation()
		{
			var scope = Parse(Constants.kRitualInvokation);
			var child = scope.Children.FirstOrDefault() as FunctionInvokation;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.FunctionName, Is.EqualTo("ᚠᛇᛒ"));
			Assert.That(child.ParameterList.Count, Is.EqualTo(1));
			Assert.That(child.ParameterList[0].Param, Is.Not.Null);
			Assert.That(child.ParameterList[0].Param.Type, Is.EqualTo(ExpressionTypes.NamedType));
			Assert.That(child.ParameterList[0].Stir, Is.EqualTo(StirDirection.Clockwise));
		}

		[Test]
		public void Add_a_b_Declare()
		{
			var scope = Parse(Constants.kRitual_Add);
			var child = scope.Children.FirstOrDefault() as FunctionDeclaration;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.FunctionName, Is.EqualTo("ᚫᛞᛞ"));
			Assert.That(child.ReturnClass.Type, Is.EqualTo(VariableTypes.U64));
			Assert.That(child.Parameters.Count, Is.EqualTo(2));
			Assert.That(child.Parameters[0].Name, Is.EqualTo("ᚫ"));
			Assert.That(child.Parameters[0].Type, Is.EqualTo(VariableTypes.U64));
			Assert.That(child.Parameters[0].Flag, Is.EqualTo(VariableFlags.Volitile));
			Assert.That(child.Parameters[0].Stir, Is.EqualTo(StirDirection.Clockwise));

			Assert.That(child.Parameters[1].Name, Is.EqualTo("ᛒ"));
			Assert.That(child.Parameters[1].Type, Is.EqualTo(VariableTypes.U64));
			Assert.That(child.Parameters[1].Flag, Is.EqualTo(VariableFlags.Volitile));
			Assert.That(child.Parameters[1].Stir, Is.EqualTo(StirDirection.Clockwise));
			Assert.That(child.FunctionScope, Is.Not.Null);
		}

		[Test] 
		public void InvokeIntoVariable()
		{
			var scope = Parse(Constants.kRitualInvokationIntoVar);
			var child = scope.Children.FirstOrDefault() as FunctionInvokation;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.FunctionName, Is.EqualTo("ᚠᛇᛒ"));
			Assert.That(child.ParameterList.Count, Is.EqualTo(1));
			Assert.That(child.ParameterList[0].Param, Is.Not.Null);
			Assert.That(child.ParameterList[0].Param.Type, Is.EqualTo(ExpressionTypes.NamedType));
			Assert.That(child.ParameterList[0].Stir, Is.EqualTo(StirDirection.Clockwise));
			Assert.That(child.RetVar, Is.EqualTo("ᚫ"));
		}
	}
}
