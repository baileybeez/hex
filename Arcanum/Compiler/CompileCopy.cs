using Hex.Arcanum.Common;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		public void HandleLoadConst(IRInst inst)
		{
			switch (inst.opCode)
			{
				default:
				case OpCode.LoadStringConst:
					// NOTE: No Operation
					break;

				case OpCode.LoadU64Const:
					Emit($"	MOV {inst.result}, {inst.leftOperand}");
					break;

				case OpCode.LoadCharConst:
					byte cb = Convert.ToByte(inst.leftOperand);
					Emit($"	MOV {inst.result}, {cb}");
					break;
			}
		}

		public void HandleCopyU64(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
		}

		public void HandleCopyChar(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
		}

		public void HandleCopyString(IRInst inst)
		{
		}

		public void HandleCopyToReg(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
		}

		public void HandleCopyFromReg(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
		}
	}
}
