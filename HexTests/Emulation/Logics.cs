
namespace HexTests.Emulation
{
	public class Logics : EmulateTestUtilities
	{
		[Test]
		public void Greater()
		{
			Emulate(Constants.kGreaterScript);
			Assert.That(_emu.GetValue("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetValue("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t2"), Is.EqualTo(false));

			Emulate(Constants.kGreaterEqScript);
			Assert.That(_emu.GetValue("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetValue("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t2"), Is.EqualTo(false));
		}

		[Test]
		public void Less()
		{
			Emulate(Constants.kLessScript);
			Assert.That(_emu.GetValue("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetValue("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t2"), Is.EqualTo(true));

			Emulate(Constants.kLessEqScript);
			Assert.That(_emu.GetValue("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetValue("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t2"), Is.EqualTo(true));
		}

		[Test] 
		public void LogicalAnd()
		{
			Emulate(Constants.kAndEqualityScript);

			Assert.That(_emu.GetValue("t2"), Is.EqualTo(true));
			Assert.That(_emu.GetValue("t5"), Is.EqualTo(true));
			Assert.That(_emu.GetValue("t6"), Is.EqualTo(true));
		}

		[Test]
		public void LogicalOr()
		{
			Emulate(Constants.kOrEqualityScript);

			Assert.That(_emu.GetValue("t2"), Is.EqualTo(false));
			Assert.That(_emu.GetValue("t5"), Is.EqualTo(true));
			Assert.That(_emu.GetValue("t6"), Is.EqualTo(true));
		}
	}
}
