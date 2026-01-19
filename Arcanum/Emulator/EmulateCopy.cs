using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void CopyByte(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			SetValue(inst.result, GetByte(inst.leftOperand));
		}

		public void CopyU64(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			SetValue(inst.result, GetU64(inst.leftOperand));
		}

		public void CopyChar(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			SetValue(inst.result, GetChar(inst.leftOperand));
		}

		public void CopyString(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			if (!_stringTable.ContainsKey(inst.leftOperand))
				throw new HexException($"String {inst.leftOperand} was not provided!");

			SetValue(inst.result, _stringTable[inst.leftOperand]);
		}
	}
}