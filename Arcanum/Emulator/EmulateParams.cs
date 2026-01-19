

using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;


namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void EmulateCopyToReg(IRInst inst)
		{
			if (inst.leftOperand == null)
				throw new HexException("No value provided.");

			UInt64 u64 = GetU64(inst.leftOperand);

			SetRegister(inst.result, u64);
		}

		public void EmulateCopyFromReg(IRInst inst)
		{
			if (inst.leftOperand == null)
				throw new HexException("No register provided.");

			UInt64 u64 = GetRegister(inst.leftOperand);
			SetValue(inst.result, u64);
		}

		public void EmulateCopyToStack(IRInst inst)
		{
			if (inst.leftOperand == null || !UInt64.TryParse(inst.leftOperand, out UInt64 u64))
				throw new HexException("No value provided.");

			if (!int.TryParse(inst.result, out var offset))
				throw new HexException("No stack offset provided.");

			SetStackValue(offset, u64);
		}

		public void EmulateCopyFromStack(IRInst inst)
		{
			// TODO: copy param from stack pos
		}
	}
}
