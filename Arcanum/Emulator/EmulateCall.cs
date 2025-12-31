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

		public void EmulateParam(IRInst inst)
		{
			if (inst.leftOperand == null)
				throw new HexException($"parameter information must be provided!");
				
			object val = GetValue(inst.leftOperand);
			_callParams.Push(val);
		}

		public void EmulateCopyParam(IRInst inst)
		{			
			object val = _callParams.Pop();
			SetValue(inst.result, val);
		}
	}
}