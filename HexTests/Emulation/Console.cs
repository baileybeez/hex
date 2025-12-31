
namespace HexTests.Emulation
{
	public class Console : EmulateTestUtilities
	{
		[Test]
		public void Redirect()
		{
			TestConsole con = new TestConsole();

			Emulate(Constants.kConsoleOutput, con);

			Assert.That(con.Logs.Count, Is.EqualTo(1));
			Assert.That(con.Logs[0], Is.EqualTo("hello world"));
		}
	}
}
