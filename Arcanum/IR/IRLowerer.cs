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

		private string NewTemp() => $"t{_tempIndex++}";
		private string NewLabel() => $"L_{_labelIndex++}";

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
			LowerExpression(rootScope);
			return _instList;
		}

		public void Emit(OpCode opCode, string result, string? leftOperand = null, string? rightOperand = null)
		{
			_instList.Add(new IRInst(opCode, result, leftOperand, rightOperand));
		}
	}
}
