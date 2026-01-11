using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.IR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexTests.IR
{
	public class Scopes : LowerTestUtilities
	{

		[Test]
		public void If()
		{
			var scope = Parse(Constants.kSimpleIfStatement);

			IRLowerer lower = new();
			var list = lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(4));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Greater));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.JumpIfFalse));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.Label));
		}

		[Test]
		public void While()
		{
			var scope = Parse(Constants.kSimpleWhileStatement);

			IRLowerer lower = new();
			var list = lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(6));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.Greater));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.JumpIfFalse));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.Jump));
			Assert.That(list[5].opCode, Is.EqualTo(OpCode.Label));
		}

		[Test]
		public void For()
		{
			var scope = Parse(Constants.kSimpleForStatement);

			IRLowerer lower = new();
			var list = lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(9));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.Greater));
			Assert.That(list[5].opCode, Is.EqualTo(OpCode.JumpIfTrue));
			Assert.That(list[6].opCode, Is.EqualTo(OpCode.Inc));
			Assert.That(list[7].opCode, Is.EqualTo(OpCode.Jump));
			Assert.That(list[8].opCode, Is.EqualTo(OpCode.Label));
		}

		[Test]
		public void IfElse()
		{
			var scope = Parse(Constants.kSimpleIfElseStatement);

			IRLowerer lower = new();
			var list = lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(6));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Greater));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.JumpIfFalse));
			Assert.That(list[2].leftOperand, Is.EqualTo("L_1"));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.Jump));
			Assert.That(list[3].leftOperand, Is.EqualTo("L_0"));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[4].result, Is.EqualTo("L_1"));
			Assert.That(list[5].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[5].result, Is.EqualTo("L_0"));
		}

		[Test]
		public void IfElseIf()
		{
			var scope = Parse(Constants.kSimpleIfElseIfStatement);

			IRLowerer lower = new();
			var list = lower.Run(scope);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(9));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Greater));
			Assert.That(list[2].opCode, Is.EqualTo(OpCode.JumpIfFalse));
			Assert.That(list[2].leftOperand, Is.EqualTo("L_1"));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.Jump));
			Assert.That(list[3].leftOperand, Is.EqualTo("L_0"));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[4].result, Is.EqualTo("L_1"));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[6].opCode, Is.EqualTo(OpCode.Less));
			Assert.That(list[7].opCode, Is.EqualTo(OpCode.JumpIfFalse));
			Assert.That(list[8].result, Is.EqualTo("L_0"));
		}
	}
}
