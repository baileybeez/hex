using Hex.Arcanum.Emulator;

namespace HexTests.Emulation
{
	public class Logics : EmulateTestUtilities
	{
		[Test]
		public void Greater()
		{
			Emulate(Constants.kGreaterScript, EmulatorMemMode.Mapped);
			Assert.That(_emu.GetU64("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetU64("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetBool("t2"), Is.EqualTo(false));

			Emulate(Constants.kGreaterEqScript, EmulatorMemMode.Mapped);
			Assert.That(_emu.GetU64("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetU64("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetBool("t2"), Is.EqualTo(false));
		}

		[Test]
		public void Less()
		{
			Emulate(Constants.kLessScript, EmulatorMemMode.Mapped);
			Assert.That(_emu.GetU64("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetU64("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetBool("t2"), Is.EqualTo(true));

			Emulate(Constants.kLessEqScript, EmulatorMemMode.Mapped);
			Assert.That(_emu.GetU64("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetU64("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetBool("t2"), Is.EqualTo(true));
		}

		[Test] 
		public void LogicalAnd()
		{
			Emulate(Constants.kAndEqualityScript, EmulatorMemMode.Mapped);

			Assert.That(_emu.GetBool("t2"), Is.EqualTo(true));
			Assert.That(_emu.GetBool("t5"), Is.EqualTo(true));
			Assert.That(_emu.GetBool("t6"), Is.EqualTo(true));
		}

		[Test]
		public void LogicalOr()
		{
			Emulate(Constants.kOrEqualityScript, EmulatorMemMode.Mapped);

			Assert.That(_emu.GetBool("t2"), Is.EqualTo(false));
			Assert.That(_emu.GetBool("t5"), Is.EqualTo(true));
			Assert.That(_emu.GetBool("t6"), Is.EqualTo(true));
		}
	}
}
