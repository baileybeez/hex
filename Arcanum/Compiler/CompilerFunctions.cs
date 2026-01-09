using Hex.Arcanum.Common;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		public void HandleLabel(IRInst inst)
		{
			Emit($"{inst.result}:");
		}

		public void HandleSetupCall(IRInst inst)
		{
			// TODO: save caller saved registers
			// TODO: setup stack for calling
		}

		public void HandleCall(IRInst inst)
		{
			Emit($"	CALL {inst.leftOperand}");
		}

		public void HandleReturn(IRInst inst)
		{
			// TODO: set RAX if necessary, jump to end of function
			Emit("	RET");
		}

		public void HandleEnterFunc(IRInst inst)
		{
			Emit("	PUSH RBP");
			Emit("	MOV RBP, RSP");

			// TODO: calculate needed stack space
			// Calculate total stack space needed
			// - Local variables (stackSlotsNeeded * 8)
			// - Callee-saved registers (calleeSavedRegs.Count * 8)
			// - Align to 16 bytes

			// TODO: save callee saved regs
		}

		public void HandleLeaveFunc(IRInst inst)
		{
			// TODO: restore callee registers 

			Emit("	LEAVE");
			// LEAVE is equiv to :
			// MOV RSP, RBP
			// POP RBP
		}
	}
}