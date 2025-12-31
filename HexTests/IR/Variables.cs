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
			Assert.That(list[0].result, Is.EqualTo("t0"));
			Assert.That(list[0].leftOperand, Is.EqualTo("1"));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Copy));
			Assert.That(list[1].result, Is.EqualTo("ᚫ"));
			Assert.That(list[1].leftOperand, Is.EqualTo("t0"));
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
			Assert.That(list[0].result, Is.EqualTo("t0"));
			Assert.That(list[0].leftOperand, Is.EqualTo("1"));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Copy));
			Assert.That(list[1].result, Is.EqualTo("ᚫ"));
			Assert.That(list[1].leftOperand, Is.EqualTo("t0"));
		}
	}
}
