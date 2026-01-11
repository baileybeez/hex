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

			Emit(OpCode.SetupCall, String.Empty, argCount.ToString());
			for (int idx = 0; idx < argCount; idx++)
			{
				if (idx < 6)
					Emit(OpCode.CopyToReg, RegisterUtils.GetByArg(idx), argTempList[idx]);
				else
					Emit(OpCode.SaveToStack, RegisterUtils.GetOffset(idx).ToString(), argTempList[idx]);
			}

			string retTemp = NewTemp();
			Emit(OpCode.Call, "RAX", $"func_{call.FunctionName}", argCount.ToString());
			if (!String.IsNullOrEmpty(call.RetVar))
			{
				string? varTemp = LookupVar(call.RetVar);
				if (varTemp == null)
				{
					varTemp = NewTemp();
					AddVar(call.RetVar, varTemp);
				}

				Emit(OpCode.CopyFromReg, varTemp, "RAX");
			}

			if (argCount > 6)
			{
				int stackSize = (argCount - 6) * 8;
				Emit(OpCode.DeallocStack, String.Empty, stackSize.ToString());
			}	

			return retTemp;
		}
	}
}
