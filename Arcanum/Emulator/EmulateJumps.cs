using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void LabelOp(IRInst inst)
		{
			// NOTE: labels are just markers
			return;
		}

		public void Jump(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			if (!_labelMap.TryGetValue(inst.leftOperand, out int ptr))
				return;

			_ip = ptr - 1; // NOTE: Emu loop will auto-increment IP after this command
		}

		public void JumpIfFalse(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			if (!_labelMap.TryGetValue(inst.leftOperand, out int ptr))
				return;

			bool b = GetBool(inst.result);
			if (b == false)
				_ip = ptr - 1; // NOTE: Emu loop will auto-increment IP after this command
		}

		public void JumpIfTrue(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			if (!_labelMap.TryGetValue(inst.leftOperand, out int ptr))
				return;

			bool b = GetBool(inst.result);
			if (b == true)
				_ip = ptr - 1; // NOTE: Emu loop will auto-increment IP after this command
		}
	}
}
