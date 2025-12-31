using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void ArithmeticOp(IRInst inst)
		{
			if (inst.leftOperand == null || inst.rightOperand == null)
				throw new HexException($"One or more invalid operands for {inst.opCode} operation");

			UInt64 left = GetU64(GetValue(inst.leftOperand));
			UInt64 right = GetU64(GetValue(inst.rightOperand));
			UInt64 res = inst.opCode switch
			{
				OpCode.Add => left + right,
				OpCode.Sub => left - right,
				OpCode.Mul => left * right,
				OpCode.Div => left / right,
				OpCode.Mod => left % right,
				_ => throw new HexException($"Invalid or unsupported arithmetic operation {inst.opCode}")
			};

			SetValue(inst.result, res);
		}

		public void Amplify(IRInst inst)
		{
			if (inst.leftOperand == null)
				throw new HexException($"One or more invalid operands for {inst.opCode} operation");

			UInt64 left = GetU64(GetValue(inst.leftOperand));			
			SetValue(inst.result, left + 1);
		}

		public void Diminish(IRInst inst)
		{
			if (inst.leftOperand == null)
				throw new HexException($"One or more invalid operands for {inst.opCode} operation");

			UInt64 left = GetU64(GetValue(inst.leftOperand));
			SetValue(inst.result, left - 1);
		}
	}
}