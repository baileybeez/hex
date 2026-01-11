
using Hex.Arcanum.Common;
using Hex.Arcanum.IR;

namespace HexTests.IR
{
	public class Arithmetic : LowerTestUtilities
	{
		public void ValidateIR(List<IRInst> list, int left, OpCode op, int right)
		{
			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(3));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[0].leftOperand, Is.EqualTo(left.ToString()));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.LoadU64Const));
			Assert.That(list[1].leftOperand, Is.EqualTo(right.ToString()));
			Assert.That(list[2].opCode, Is.EqualTo(op));
			Assert.That(list[2].leftOperand, Is.EqualTo("t0"));
			Assert.That(list[2].rightOperand, Is.EqualTo("t1"));
		}

		[Test]
		public void Add()
		{
			var scope = Parse("1 + 1");

			IRLowerer lower = new();
			var list = lower.Run(scope);

			ValidateIR(list, 1, OpCode.Add, 1);
		}

		[Test]
		public void Sub()
		{
			var scope = Parse("1 - 1");

			IRLowerer lower = new();
			var list = lower.Run(scope);

			ValidateIR(list, 1, OpCode.Sub, 1);
		}

		[Test]
		public void Mul()
		{
			var scope = Parse("1 * 1");

			IRLowerer lower = new();
			var list = lower.Run(scope);

			ValidateIR(list, 1, OpCode.Mul, 1);
		}

		[Test]
		public void Div()
		{
			var scope = Parse("1 / 1");

			IRLowerer lower = new();
			var list = lower.Run(scope);

			ValidateIR(list, 1, OpCode.Div, 1);
		}

		[Test]
		public void Inc()
		{
			var scope = Parse(Constants.kAmp);

			IRLowerer lower = new();
			var list = lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(1));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Inc));
			Assert.That(list[0].leftOperand, Is.EqualTo("ᚫ"));
			Assert.That(list[0].result, Is.EqualTo("ᚫ"));
		}

		[Test]
		public void Dec()
		{
			var scope = Parse(Constants.kDim);

			IRLowerer lower = new();
			var list = lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(1));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Dec));
			Assert.That(list[0].leftOperand, Is.EqualTo("ᚫ"));
			Assert.That(list[0].result, Is.EqualTo("ᚫ"));

		}
	}
}
