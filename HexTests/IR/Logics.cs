
using Hex.Arcanum.Common;
using Hex.Arcanum.IR;

namespace HexTests.IR
{
	public class Logics : LowerTestUtilities
	{
		IRLowerer _lower = new();

		public void LogicValidation(List<IRInst> list, OpCode op)
		{
			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(3));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[2].opCode, Is.EqualTo(op));
		}

		[Test]
		public void Equality()
		{
			var scope = Parse(Constants.kEqualityScript);
			var list = _lower.Run(scope);

			LogicValidation(list, OpCode.Equal);
		}

		[Test]
		public void Inequality()
		{
			var scope = Parse(Constants.kInequalityScript);
			var list = _lower.Run(scope);

			LogicValidation(list, OpCode.NotEqual);
		}

		[Test]
		public void Greater()
		{
			var scope = Parse(Constants.kGreaterScript);
			var list = _lower.Run(scope);

			LogicValidation(list, OpCode.Greater);
		}


		[Test]
		public void GreaterOrEqual()
		{
			var scope = Parse(Constants.kGreaterEqScript);
			var list = _lower.Run(scope);

			LogicValidation(list, OpCode.GreaterEqual);
		}

		[Test]
		public void Less()
		{
			var scope = Parse(Constants.kLessScript);
			var list = _lower.Run(scope);

			LogicValidation(list, OpCode.Less);
		}


		[Test]
		public void LessOrEqual()
		{
			var scope = Parse(Constants.kLessEqScript);
			var list = _lower.Run(scope);

			LogicValidation(list, OpCode.LessEqual);
		}
	}
}