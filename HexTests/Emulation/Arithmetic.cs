using Hex.Arcanum.Emulator;

namespace HexTests.Emulation
{
	public class Arithmetic : EmulateTestUtilities
	{
		[Test]
		public void Add()
		{
			Emulate(Constants.kSimpleScript, EmulatorMemMode.Mapped);
			Assert.That(_emu.GetU64("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetU64("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetU64("t2"), Is.EqualTo(3));

			Emulate(Constants.kParenScript, EmulatorMemMode.Mapped);
			Assert.That(_emu.GetU64("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetU64("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetU64("t2"), Is.EqualTo(3));
			Assert.That(_emu.GetU64("t3"), Is.EqualTo(3));
			Assert.That(_emu.GetU64("t4"), Is.EqualTo(9));
		}
	}
}
