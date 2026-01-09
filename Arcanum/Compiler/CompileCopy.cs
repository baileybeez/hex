using Hex.Arcanum.Common;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		public void HandleLoadConst(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
		}

		public void HandleCopy(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
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
