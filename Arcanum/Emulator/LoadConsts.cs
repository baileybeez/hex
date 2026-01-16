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

		public void LoadCharConst(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			char cb = inst.leftOperand[0];
			SetValue(inst.result, cb);
		}

		public void LoadStringConst(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			string str = inst.leftOperand;
			SetValue(inst.result, str);
		}
	}
}