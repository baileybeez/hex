
namespace HexTests.Emulation
{
	public class Scopes : EmulateTestUtilities
	{
		[Test]
		public void For()
		{
			Emulate(Constants.kSimpleForStatement);

			var condition = _emu.GetValue("t1");
			var itor = _emu.GetValue("t0");

			Assert.That(condition, Is.EqualTo(true));
			Assert.That(itor, Is.EqualTo(10));
		}
	}
}
