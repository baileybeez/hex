using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		private List<IRInst> _instList = new();
		private int _tempIndex = 0;
		private int _labelIndex = 0;
		private int _strIndex = 0;

		private string NewTemp() => $"t{_tempIndex++}";
		private string NewLabel() => $"L_{_labelIndex++}";
		private string NewString() => $"STR_{_strIndex++}";

		public IRLowerer()
		{
			SetupHandlerMap();
		}

		public void Reset()
		{
			_instList.Clear();
			_tempIndex = 0;
			_labelIndex = 0;
		}

		public List<IRInst> Run(Scope rootScope)
		{
			_instList.Clear();

			var entryPoint = rootScope.FindEntryPoint()?.FunctionName;
			if (entryPoint != null)
			{
				_instList.Add(new IRInst(OpCode.Call, string.Empty, $"func_{entryPoint}", null));
				_instList.Add(new IRInst(OpCode.Exit, string.Empty, null, null));
			}
			LowerExpression(rootScope);
			return _instList;
		}

		public List<IRInst> RunOnRitual(FunctionDeclaration fnc)
		{
			_instList.Clear();
			LowerFunctionDeclaration(fnc);
			return _instList;
		}

		public void Emit(OpCode opCode, string result, string? leftOperand = null, string? rightOperand = null)
		{
			_instList.Add(new IRInst(opCode, result, leftOperand, rightOperand));
		}
	}
}
