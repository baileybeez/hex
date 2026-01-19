using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void LogicOp(IRInst inst)
		{
			if (inst.leftOperand == null || inst.rightOperand == null)
				throw new HexException($"One or more invalid operands for {inst.opCode} operation");

			UInt64 uLeft = GetU64(inst.leftOperand);
			UInt64 uRight = GetU64(inst.rightOperand);
			bool res = inst.opCode switch
			{
				OpCode.Equal => uLeft == uRight,
				OpCode.NotEqual => uLeft != uRight,
				OpCode.Greater => uLeft > uRight,
				OpCode.GreaterEqual => uLeft >= uRight,
				OpCode.Less => uLeft < uRight,
				OpCode.LessEqual => uLeft <= uRight,
				OpCode.And => (GetBool(inst.leftOperand) && GetBool(inst.rightOperand)),
				OpCode.Or => (GetBool(inst.leftOperand) || GetBool(inst.rightOperand)),
				_ => throw new HexException($"Invalid or unsupported logic operation {inst.opCode}")
			};

			SetValue(inst.result, res);
		}
	}
}