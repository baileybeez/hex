using Hex.Arcanum.Emulator;

namespace HexTests.Emulation
{
	public class Conjures : EmulateTestUtilities
	{
		[Test]
		public void CharVar()
		{
			Emulate(Constants.kConjureChar, EmulatorMemMode.Mapped);

			Assert.That(_emu.MemCount(), Is.EqualTo(2));
			Assert.That(_emu.GetChar("t1"), Is.EqualTo('A'));
		}

		[Test]
		public void StringVar()
		{
			Emulate(Constants.kConjureString, EmulatorMemMode.Mapped);

			Assert.That(_emu.GetUsedMemoryCount() - Emulator.kBaseAddr, Is.EqualTo(12));
			Assert.That(_emu.LookupString("STR_0"), Is.EqualTo(Emulator.kBaseAddr));
			Assert.That(_emu.ReadString(Emulator.kBaseAddr), Is.EqualTo("hello world"));
		}
	}
}
