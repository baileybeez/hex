
namespace HexTests.Emulation
{
	public class Conjures : EmulateTestUtilities
	{
		[Test]
		public void CharVar()
		{
			Emulate(Constants.kConjureChar);

			Assert.That(_emu.MemCount(), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t1"), Is.EqualTo('A'));
		}

		[Test]
		public void StringVar()
		{
			Emulate(Constants.kConjureString);

			Assert.That(_emu.MemCount(), Is.EqualTo(2));
			Assert.That(_emu.GetValue("t0"), Is.EqualTo("hello world"));
		}
	}
}
