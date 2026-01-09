using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		private readonly Dictionary<OpCode, Action<IRInst>> _handlerMap = new();

		private void SetupHandlerMap()
		{
			_handlerMap.Clear();
			_handlerMap[OpCode.LoadU64Const] = LoadU64Const;
			_handlerMap[OpCode.Copy] = CopyU64;

			_handlerMap[OpCode.Add] = ArithmeticOp;
			_handlerMap[OpCode.Sub] = ArithmeticOp;
			_handlerMap[OpCode.Mul] = ArithmeticOp;
			_handlerMap[OpCode.Div] = ArithmeticOp;
			_handlerMap[OpCode.Inc] = Amplify;
			_handlerMap[OpCode.Dec] = Diminish;

			_handlerMap[OpCode.Equal] = LogicOp;
			_handlerMap[OpCode.NotEqual] = LogicOp;
			_handlerMap[OpCode.Greater] = LogicOp;
			_handlerMap[OpCode.GreaterEqual] = LogicOp;
			_handlerMap[OpCode.Less] = LogicOp;
			_handlerMap[OpCode.LessEqual] = LogicOp;
			_handlerMap[OpCode.And] = LogicOp;
			_handlerMap[OpCode.Or] = LogicOp;

			_handlerMap[OpCode.Label] = LabelOp;
			_handlerMap[OpCode.JumpIfFalse] = JumpIfFalse;
			_handlerMap[OpCode.JumpIfTrue] = JumpIfTrue;
			_handlerMap[OpCode.Jump] = Jump;

			_handlerMap[OpCode.Call] = EmulateCall;
			_handlerMap[OpCode.Return] = EmulateReturn;

			_handlerMap[OpCode.SetupCall] = EmulateSetupCall;
			_handlerMap[OpCode.EnterFunc] = EmulateEnterFunc;
			_handlerMap[OpCode.LeaveFunc] = EmulateLeaveFunc;

			_handlerMap[OpCode.CopyToReg] = EmulateCopyToReg;
			_handlerMap[OpCode.CopyFromReg] = EmulateCopyFromReg;
			_handlerMap[OpCode.SaveToStack] = EmulateCopyToStack;
			_handlerMap[OpCode.LoadFromStack] = EmulateCopyFromStack;

			_handlerMap[OpCode.Exit] = EmulateExit;
			_handlerMap[OpCode.Whisper] = EmulateWhisper;
		}
	}
}