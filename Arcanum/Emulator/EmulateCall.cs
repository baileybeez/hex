using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		private readonly Stack<CallStackEntry> _callStack = new();
		private readonly Stack<object> _callParams = new();

		public void EmulateCall(IRInst inst)
		{
			var entry = new CallStackEntry(_ip, inst.result);

			_callStack.Push(entry);
			Jump(inst);
		}

		public void EmulateSetupCall(IRInst inst)
		{
			// determine stackSize
			int stackSize = 0;
			if (Int32.TryParse(inst.leftOperand, out int count))
				stackSize = RegisterUtils.GetStackSize(count);

			// TODO: need to store this value somewhere?
			AllocateStackSpace(stackSize);
		}

		public void EmulateEnterFunc(IRInst inst)
		{

		}

		public void EmulateLeaveFunc(IRInst inst)
		{

		}
	}
}