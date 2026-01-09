
using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		private readonly Dictionary<OpCode, Action<IRInst>> _handlerMap = new();

		public void SetupHandlerMap()
		{
			_handlerMap.Clear();
			_handlerMap.Add(OpCode.Exit, HandlePlatformExit);
			_handlerMap.Add(OpCode.Whisper, HandleWhisper);

			_handlerMap.Add(OpCode.Label, HandleLabel);
			_handlerMap.Add(OpCode.SetupCall, HandleSetupCall);
			_handlerMap.Add(OpCode.Call, HandleCall);
			_handlerMap.Add(OpCode.EnterFunc, HandleEnterFunc);
			_handlerMap.Add(OpCode.LeaveFunc, HandleLeaveFunc);
			_handlerMap.Add(OpCode.Return, HandleReturn);

			_handlerMap.Add(OpCode.LoadU64Const, HandleLoadConst);
			_handlerMap.Add(OpCode.Copy, HandleCopy);
			_handlerMap.Add(OpCode.CopyToReg, HandleCopyToReg);
			_handlerMap.Add(OpCode.CopyFromReg, HandleCopyFromReg);

			_handlerMap.Add(OpCode.Greater, HandleLogic);

			_handlerMap.Add(OpCode.Jump, HandleJump);
			_handlerMap.Add(OpCode.JumpIfTrue, HandleJumpIfTrue);
			_handlerMap.Add(OpCode.JumpIfFalse, HandleJumpIfFalse);

			_handlerMap.Add(OpCode.Add, HandleAdd);
			_handlerMap.Add(OpCode.Sub, HandleSub);
			_handlerMap.Add(OpCode.Mul, HandleMul);
			_handlerMap.Add(OpCode.Div, HandleDiv);
			_handlerMap.Add(OpCode.Mod, HandleMod);

			_handlerMap.Add(OpCode.Inc, HandleInc);
			_handlerMap.Add(OpCode.Dec, HandleDec);
		}

		public void CompileInstruction(IRInst inst)
		{
			if (!_handlerMap.TryGetValue(inst.opCode, out var handler))
				throw new HexException($"No compiler handler defined for '{inst.opCode}'");

			handler(inst);
		}
	}
}