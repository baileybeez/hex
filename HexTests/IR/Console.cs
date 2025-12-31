
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
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.Whisper));
			Assert.That(list[0].leftOperand, Is.EqualTo("hello world"));
		}
	}
}
