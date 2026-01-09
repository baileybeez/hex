
using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		public void HandleAdd(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
			Emit($"	ADD {inst.result}, {inst.rightOperand}");
		}

		public void HandleSub(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
			Emit($"	SUB {inst.result}, {inst.rightOperand}");
		}

		public void HandleMul(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
			Emit($"	MUL {inst.result}, {inst.rightOperand}");
		}

		public void HandleDiv(IRInst inst)
		{
			throw new NotImplementedException();
		}

		public void HandleMod(IRInst inst)
		{
			throw new NotImplementedException();
		}

		public void HandleInc(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
			Emit($"	INC {inst.result}");
			// TODO: improve INC to a single ASM (it'll also call a Copy after this line)
			//Emit($"	INC {inst.result}");
		}


		public void HandleDec(IRInst inst)
		{
			Emit($"	MOV {inst.result}, {inst.leftOperand}");
			Emit($"	DEC {inst.result}");
			// TODO: improve DEC to a single ASM (it'll also call a Copy after this line)
			//Emit($"	INC {inst.result}");
		}
	}
}
