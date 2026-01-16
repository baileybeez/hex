using Hex.Arcanum.Common;
using Hex.Arcanum.IR;


namespace HexTests.IR
{
	public class Variables : LowerTestUtilities
	{
		IRLowerer _lower = new();

		[Test]
		public void DeclareWithValue()
		{
			var scope = Parse(Constants.kConjureVarAssign);
			_lower.Reset();
			var list = _lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(2));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[0].result, Is.EqualTo("t1"));
			Assert.That(list[0].leftOperand, Is.EqualTo("1"));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.CopyU64));
			Assert.That(list[1].result, Is.EqualTo("t0"));
			Assert.That(list[1].leftOperand, Is.EqualTo("t1"));
		}

		[Test]
		public void Assignment()
		{
			var scope = Parse(Constants.kAssignmentScript);
			_lower.Reset();
			var list = _lower.Run(scope);
			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(2));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[0].result, Is.EqualTo("t1"));
			Assert.That(list[0].leftOperand, Is.EqualTo("1"));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.CopyU64));
			Assert.That(list[1].result, Is.EqualTo("t0"));
			Assert.That(list[1].leftOperand, Is.EqualTo("t1"));
		}

		[Test]
		public void CharVar()
		{
			var scope = Parse(Constants.kConjureChar);
			
			_lower.Reset();
			var list = _lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(2));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.LoadCharConst));
			Assert.That(list[0].result, Is.EqualTo("t1"));
			Assert.That(list[0].leftOperand, Is.EqualTo("A"));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.CopyChar));
			Assert.That(list[1].result, Is.EqualTo("t0"));
			Assert.That(list[1].leftOperand, Is.EqualTo("t1"));
		}

		[Test] 
		public void StringVar()
		{
			var scope = Parse(Constants.kConjureString);

			_lower.Reset();
			var list = _lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(2));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.LoadStringConst));
			Assert.That(list[0].result, Is.EqualTo("STR_0"));
			Assert.That(list[0].leftOperand, Is.EqualTo("hello world"));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.CopyString));
			Assert.That(list[1].result, Is.EqualTo("t0"));
			Assert.That(list[1].leftOperand, Is.EqualTo("STR_0"));
		}
	}
}
