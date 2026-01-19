using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerAssignment(Expression expr)
		{
			var assign = AssertValid<AssignmentStatement>(expr);

			Variable? var = LookupVariable(assign.VarName);
			if (var == null)
				throw new HexException($"{assign.VarName} used before being conjured.");

			string? varTemp = LookupMappedVar(assign.VarName);
			if (varTemp == null)
			{
				varTemp = NewTemp();
				AddMappedVar(assign.VarName, varTemp);
			}

			string valTemp = LowerExpression(assign.ValueExpression);
			OpCode opCopy = OpCode.None;
			switch (var.Type)
			{
				default:
					throw new HexException($"Unsupported type: '{var.Type}'");
				case VariableTypes.U64:
					opCopy = OpCode.CopyU64;
					break;
				case VariableTypes.Char:
					opCopy = OpCode.CopyChar;
					break;
				case VariableTypes.String:
					opCopy = OpCode.CopyU64;
					break;
			}
			Emit(opCopy, varTemp, valTemp);

			return varTemp;
		}
	}
}
