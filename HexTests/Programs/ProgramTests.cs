using HexTests.Emulation;

namespace HexTests.Programs
{
	public class ProgramTests : EmulateTestUtilities
	{
		[Test]
		public void SimpleAdd()
		{
			TestConsole con = new TestConsole();

			Emulate(Constants.kRitual_Add_Call, con);

			Assert.That(con.Logs.Count, Is.EqualTo(1));
			Assert.That(con.Logs[0], Is.EqualTo("5"));
		}

		[Test]
		public void Fibonacci()
		{
			TestConsole con = new TestConsole();
			Emulate(Constants.kFiboProgram, con);

			Assert.That(con.Logs.Count, Is.EqualTo(11));
			Assert.That(con.Logs[0], Is.EqualTo("1"));
			Assert.That(con.Logs[4], Is.EqualTo("5"));
			Assert.That(con.Logs[7], Is.EqualTo("21"));
			Assert.That(con.Logs[10], Is.EqualTo("89"));
		}
	}
}
