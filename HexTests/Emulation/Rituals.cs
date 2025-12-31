
namespace HexTests.Emulation
{
	public class Rituals : EmulateTestUtilities
	{
		[Test]
		public void Decl_and_Call_Add_a_b()
		{
			Emulate(Constants.kRitual_Add_Call);

			Assert.That(_emu.MemCount(), Is.EqualTo(8));
			Assert.That(U64Val("t0"), Is.EqualTo(3));
			Assert.That(U64Val("t1"), Is.EqualTo(2));
			Assert.That(U64Val("t5"), Is.EqualTo(5));
			Assert.That(U64Val("t6"), Is.EqualTo(0));
		}

		[Test]
		public void NestedRitualCalls()
		{
			const UInt64 ans = 9;
			Emulate(Constants.kRitual_NestedCalls);

			Assert.That(_emu.MemCount(), Is.EqualTo(10));
			Assert.That(U64Val("t6"), Is.EqualTo(ans));
		}
	}
}
