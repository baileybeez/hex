
namespace Hex.Arcanum.Common
{
	public enum OpCode
	{
		// system
		None = 0,
		Nop = 1,
		Exit = 2,
		Whisper = 3,

		// arithmetic
		Add = 10, 
		Sub = 11, 
		Mul = 12, 
		Div = 13,
		Inc = 14,
		Dec = 15,
		Mod = 16,

		// comparison
		Equal = 20,
		NotEqual = 21,
		Greater = 22,
		GreaterEqual = 23,
		Less = 24,
		LessEqual = 25,
		Not = 26,
		And = 27,
		Or = 28,

		// assignment
		Copy = 31,
		LoadU64Const = 32,

		// control flow
		Jump = 40,
		JumpIfFalse = 41, 
		JumpIfTrue = 42,
		Label = 43,

		// memory
		Load = 50,
		Store = 51,
		LoadAddr = 52,

		// 
		Convert = 60,

		// stack
		Push = 70,
		Pop = 71,
		AllocStack = 72,
		DeallocStack = 73,

		// functions
		Call = 90,
		Return = 91,
		Param = 92,
		CopyParam = 93,
	}

	// 3AC approach
	public record IRInst(OpCode opCode, string result, string? leftOperand, string? rightOperand);
}
