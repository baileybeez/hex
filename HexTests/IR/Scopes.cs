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
			Assert.That(list.Count, Is.EqualTo(10));
			Assert.That(list[3].opCode, Is.EqualTo(OpCode.Label));
			Assert.That(list[4].opCode, Is.EqualTo(OpCode.GreaterEqual));
			Assert.That(list[5].opCode, Is.EqualTo(OpCode.JumpIfTrue));
			Assert.That(list[6].opCode, Is.EqualTo(OpCode.Inc));
			Assert.That(list[8].opCode, Is.EqualTo(OpCode.Jump));
			Assert.That(list[9].opCode, Is.EqualTo(OpCode.Label));
		}
	}
}
