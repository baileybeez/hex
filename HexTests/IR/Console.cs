
using Hex.Arcanum.Common;

namespace HexTests.IR
{
	public  class Console : LowerTestUtilities
	{
		[Test]
		public void LowerWhisper()
		{
			var list = Lower(Constants.kConsoleOutput);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(2));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.LoadStringConst));
			Assert.That(list[0].result, Is.EqualTo("STR_0"));
			Assert.That(list[0].leftOperand, Is.EqualTo("hello world"));
			Assert.That(list[1].opCode, Is.EqualTo(OpCode.Whisper));
			Assert.That(list[1].leftOperand, Is.EqualTo("STR_0"));
		}
	}
}
