
namespace HexTests.Emulation
{
	public class Arithmetic : EmulateTestUtilities
	{
		[Test]
		public void Add()
		{
			Emulate(Constants.kSimpleScript);
			Assert.That(_emu.GetValue("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetValue("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t2"), Is.EqualTo(3));

			Emulate(Constants.kParenScript);
			Assert.That(_emu.GetValue("t0"), Is.EqualTo(1));
			Assert.That(_emu.GetValue("t1"), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t2"), Is.EqualTo(3));
			Assert.That(_emu.GetValue("t3"), Is.EqualTo(3));
			Assert.That(_emu.GetValue("t4"), Is.EqualTo(9));
		}
	}
}
