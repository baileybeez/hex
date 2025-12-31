using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerFunctionInvokation(Expression expr)
		{
			var call = AssertValid<FunctionInvokation>(expr);

			int argCount = call.ParameterList.Count;
			var argTempList = new List<string>();
			foreach (InvokationParam ip in call.ParameterList)
			{
				string arg = LowerExpression(ip.Param);
				argTempList.Add(arg);
			}
						
			for (int idx = 0; idx < argCount; idx++)
				Emit(OpCode.Param, String.Empty, argTempList[idx]);

			string retTemp = NewTemp();
			Emit(OpCode.Call, retTemp, $"func_{call.FunctionName}", argCount.ToString());
			if (!String.IsNullOrEmpty(call.RetVar))
				Emit(OpCode.Copy, call.RetVar, retTemp);

			return retTemp;
		}
	}
}
