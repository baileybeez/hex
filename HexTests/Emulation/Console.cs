using Hex.Arcanum.Emulator;

namespace HexTests.Emulation
{
	public class Console : EmulateTestUtilities
	{
		[Test]
		public void Redirect()
		{
			TestConsole con = new TestConsole();

			Emulate(Constants.kConsoleOutput, EmulatorMemMode.Raw, con);

			Assert.That(con.Logs.Count, Is.EqualTo(1));
			Assert.That(con.Logs[0], Is.EqualTo("hello world"));
		}
	}
}
