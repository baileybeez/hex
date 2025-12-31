using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		// NOTE: RBX, RSP, RBP, and R12–R15 callee saved
		public string LowerFunctionDeclaration(Expression expr)
		{
			var fncHeader = AssertValid<FunctionDeclaration>(expr);
			Emit(OpCode.Label, $"func_{fncHeader.FunctionName}");

			_paramMap.Clear();
			for (int idx = fncHeader.Parameters.Count - 1; idx >= 0; idx--)
			{
				var temp = NewTemp();
				var param = fncHeader.Parameters[idx];

				Emit(OpCode.CopyParam, temp, param.Name);
				_paramMap.Add(param.Name, temp);
			}

			// check for return command and emit a void return if needed
			string retval = LowerScope(fncHeader.FunctionScope);
			if (retval == kMissingRetVal)
			{
				retval = NewTemp();
				Emit(OpCode.LoadU64Const, retval, "0");
				Emit(OpCode.Return, retval);
			}
			return String.Empty;
		}
	}
}
