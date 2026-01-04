
using Hex.Arcanum.Emulator;

namespace HexTests.Emulation
{
	public class ParamTests : EmulateTestUtilities
	{
		// TODO: register tests

		[Test]
		public void StackTests()
		{
			const int stackSpace = 24;
			const int stackTop = Emulator.kMaxStackSize - 1;
			const int targetSp = stackTop - stackSpace;
			const UInt64 a = 0x6508;
			const UInt64 b = 0xAB99;
			UInt64 ret = UInt64.MaxValue;

			_emu.AllocateStackSpace(stackSpace);
			Assert.That(_emu.StackPointer, Is.EqualTo(targetSp));

			_emu.SetStackValue(0, a);
			ret = _emu.GetStackValue(0);
			Assert.That(ret, Is.EqualTo(a));

			_emu.SetStackValue(8, b);
			ret = _emu.GetStackValue(8);
			Assert.That(ret, Is.EqualTo(b));

			_emu.ReleaseStackSpace(stackSpace);
			Assert.That(_emu.StackPointer, Is.EqualTo(stackTop));
		}
	}
}
