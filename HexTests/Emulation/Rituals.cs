
namespace HexTests.Emulation
{
	public class Rituals : EmulateTestUtilities
	{
		[Test]
		public void Decl_and_Call_Add_a_b()
		{
			Emulate(Constants.kRitual_Add_Call);

			Assert.That(_emu.MemCount(), Is.EqualTo(5));
			Assert.That(U64Val("t0"), Is.EqualTo(3));
			Assert.That(U64Val("t3"), Is.EqualTo(2));
			Assert.That(U64Val("t1"), Is.EqualTo(5));
			Assert.That(U64Val("t2"), Is.EqualTo(5));
		}

		[Test]
		public void NestedRitualCalls()
		{
			const UInt64 ans = 9;
			Emulate(Constants.kRitual_NestedCalls);

			Assert.That(_emu.MemCount(), Is.EqualTo(7));
			Assert.That(_emu.GetRegister("RDI"), Is.EqualTo(4));
			Assert.That(_emu.GetRegister("RAX"), Is.EqualTo(ans));
			Assert.That(U64Val("t5"), Is.EqualTo(ans));
		}
	}
}
