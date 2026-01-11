using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerFunctionDeclaration(Expression expr)
		{
			var fncHeader = AssertValid<FunctionDeclaration>(expr);
			Emit(OpCode.Label, $"func_{fncHeader.FunctionName}");
			Emit(OpCode.EnterFunc, String.Empty, "0");

			PushScope();
			for (int idx = fncHeader.Parameters.Count - 1; idx >= 0; idx--)
			{
				var param = fncHeader.Parameters[idx];
				var temp = NewTemp();

				if (idx < 6)
					Emit(OpCode.CopyFromReg, temp, param.Location);
				else
					Emit(OpCode.LoadFromStack, temp, param.Location);

				AddVar(param.Name, temp);
			}

			// check for return command and emit a void return if needed
			string retval = LowerScope(fncHeader.FunctionScope);
			if (retval == kMissingRetVal)
			{
				Emit(OpCode.LeaveFunc, String.Empty);
				Emit(OpCode.Return, String.Empty);
			}

			PopScope();
			return String.Empty;
		}
	}
}
