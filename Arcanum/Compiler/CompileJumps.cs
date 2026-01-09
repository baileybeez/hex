using Hex.Arcanum.Common;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		public void HandleJump(IRInst inst)
		{
			Emit($"	JMP	{inst.leftOperand}");
		}

		public void HandleJumpIfTrue(IRInst inst)
		{
			Emit($"	TEST	{inst.result}, {inst.result}");
			Emit($"	JNZ	{inst.leftOperand}");
		}

		public void HandleJumpIfFalse(IRInst inst)
		{
			Emit($"	TEST	{inst.result}, {inst.result}");
			Emit($"	JZ		{inst.leftOperand}");
		}
	}
}