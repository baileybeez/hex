
using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		public void HandleLogic(IRInst inst)
		{
			string setOp = "";
			switch (inst.opCode)
			{
				default:
					throw new HexException($"Unsupported logic operation: '{inst.opCode}'");

				case OpCode.Greater:
					setOp = "G";
					break;

				case OpCode.GreaterEqual:
					setOp = "GE";
					break;

				case OpCode.Less:
					setOp = "L";
					break;

				case OpCode.LessEqual:
					setOp = "LE";
					break;

				case OpCode.Equal:
					setOp = "E";
					break;

				case OpCode.NotEqual:
					setOp = "NE";
					break;
			}

			Emit($"	XOR	{inst.result}, {inst.result}");
			Emit($"	CMP	{inst.leftOperand}, {inst.rightOperand}");
			Emit($"	SET{setOp}	{inst.result}b");
		}
	}
}
