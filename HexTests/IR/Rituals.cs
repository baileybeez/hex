using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.IR;

namespace HexTests.IR
{
	public class Rituals : LowerTestUtilities
	{
		[Test]
		public void Declaration()
		{
			var list = Lower(Constants.kRitualDeclaration);

			Assert.That(list.Count, Is.EqualTo(4));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.CopyParam));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.Return));
		}

		[Test]
		public void Invokation()
		{
			var list = Lower(Constants.kRitualInvokation);

			Assert.That(list.Count, Is.EqualTo(2));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Param));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Call));
		}

		[Test]
		public void Decl_Add_a_b()
		{
			var list = Lower(Constants.kRitual_Add);

			Assert.That(list.Count, Is.EqualTo(5));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.CopyParam));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.CopyParam));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.Add));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.Return));
		}

		[Test]
		public void Decl_and_Call_Add_a_b()
		{
			var list = Lower(Constants.kRitual_Add_Call);

			Assert.That(list.Count, Is.EqualTo(17));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Call));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Exit));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.CopyParam));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.CopyParam));
			Assert.That(list[5].opCode, Is.EqualTo(OpCode.Add));
			Assert.That(list[6].opCode, Is.EqualTo(OpCode.Return));
			Assert.That(list[7].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[8].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[9].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[10].opCode, Is.EqualTo(OpCode.Param));
			Assert.That(list[11].opCode, Is.EqualTo(OpCode.Param));
			Assert.That(list[12].opCode, Is.EqualTo(OpCode.Call));
			Assert.That(list[13].opCode, Is.EqualTo(OpCode.Copy));
			Assert.That(list[14].opCode, Is.EqualTo(OpCode.Whisper));
			Assert.That(list[15].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[16].opCode, Is.EqualTo(OpCode.Return));
		}

		[Test]
		public void InvokeIntoVariable()
		{
			var list = Lower(Constants.kRitualInvokationIntoVar);

			Assert.That(list.Count, Is.EqualTo(3));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Param));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Call));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.Copy));
		}
	}
}
