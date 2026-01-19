
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
		LoadU64Const = 30,
		LoadCharConst = 31,
		LoadStringConst = 32,

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
		CopyU64 = 60, 
		CopyChar = 61, 
		CopyString = 62,
		CopyByte = 63,

		// stack
		Push = 70,
		Pop = 71,
		AllocStack = 72,
		DeallocStack = 73,

		// Registers
		CopyToReg = 80,
		CopyFromReg = 81,
		SaveToStack = 82,
		LoadFromStack = 83,

		// functions
		Call = 90,
		Return = 91,
		Param = 92,
		CopyParam = 93,
		EnterFunc = 94,
		LeaveFunc = 95,
		SetupCall = 96,
	}

	// 3AC approach
	public record IRInst(OpCode opCode, string result, string? leftOperand, string? rightOperand);

	public sealed class IRFile
	{
		public static void WriteIR(BinaryWriter bw, IRInst inst)
		{
			bw.Write((Int32)inst.opCode);
			bw.Write(inst.result);
			bw.Write(inst.leftOperand ?? "\0");
			bw.Write(inst.rightOperand ?? "\0");
		}

		public static IRInst ReadIR(BinaryReader br)
		{
			OpCode op = (OpCode)br.ReadInt32();
			string result = br.ReadString();
			string left = br.ReadString();
			string right = br.ReadString();

			string? leftOp = left == "\0" ? null : left;
			string? rightOp = right == "\0" ? null : right;

			return new IRInst(op, result, leftOp, rightOp);
		}

		public static void Save(string filePath, List<IRInst> irList)
		{
			using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			using var bw = new BinaryWriter(fs, System.Text.Encoding.UTF8);

			// TODO: other header info?
			bw.Write((Int32)irList.Count);
			foreach (IRInst ir in irList)
				WriteIR(bw, ir);
		}

		public static List<IRInst> Load(string filePath)
		{
			using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			using var br = new BinaryReader(fs, System.Text.Encoding.UTF8);

			List<IRInst> list = new();

			// TODO: other header info?
			int count = br.ReadInt32();
			for (int i = 0; i < count; i++)
				list.Add(ReadIR(br));

			return list;
		}
	}
}
