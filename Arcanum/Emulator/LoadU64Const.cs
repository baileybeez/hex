using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void LoadU64Const(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			if (UInt64.TryParse(inst.leftOperand, out UInt64 val))
				SetValue(inst.result, val);
		}
	}
}