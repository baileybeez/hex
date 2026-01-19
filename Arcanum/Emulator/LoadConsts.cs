using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using System.Net;

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

			UInt64 addr = AllocateString(inst.leftOperand);
			_stringTable[inst.result] = addr;
		}
	}
}