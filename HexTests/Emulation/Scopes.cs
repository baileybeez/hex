using Hex.Arcanum.Emulator;

namespace HexTests.Emulation
{
	public class Scopes : EmulateTestUtilities
	{
		[Test]
		public void For()
		{
			Emulate(Constants.kSimpleForStatement, EmulatorMemMode.Mapped);

			var condition = _emu.GetBool("t1");
			var itor = _emu.GetU64("t0");

			Assert.That(condition, Is.EqualTo(true));
			Assert.That(itor, Is.EqualTo(11));
		}
	}
}
