using Hex.Arcanum.Common;

namespace HexTests.IR
{
	public class Pointers : LowerTestUtilities
	{
		[Test]
		public void StringPointer()
		{
			var list = Lower(Constants.kStringPointer);

			Assert.That(list, Is.Not.Null);
			Assert.Ignore();
		}

		[Test]
		public void DeRef()
		{
			var list = Lower(Constants.kDeRefPointer);

			Assert.That(list, Is.Not.Null);
			Assert.That(list.Count, Is.EqualTo(1));
			Assert.That(list[0].opCode, Is.EqualTo(OpCode.CopyByte));
			Assert.That(list[0].result, Is.EqualTo("t0"));
			Assert.That(list[0].leftOperand, Is.EqualTo("[ᚫ]"));
		}
	}
}
