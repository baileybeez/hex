using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void EmulateReturn(IRInst inst)
		{
			var entry = _callStack.Pop();
			if (inst.leftOperand != null && !String.IsNullOrEmpty(entry.ReturnVar))
				SetValue(entry.ReturnVar, GetValue(inst.leftOperand));

			_ip = entry.ReturnIP;
		}
	}
}