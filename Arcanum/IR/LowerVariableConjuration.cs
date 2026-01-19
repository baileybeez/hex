using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerVariableConjuration(Expression expr)
		{
			var conj = AssertValid<VariableConjuration>(expr);
			
			AddVariable(conj.Name, conj.ValueType, conj.Flag);
			if (conj.InitialValue != null)
			{
				string temp = NewTemp();
				string? val = LowerExpression(conj.InitialValue);

				OpCode opCopy = OpCode.None;
				switch (conj.ValueType)
				{
					default:
						throw new HexException($"Unsupported copy request: '{conj.ValueType}'");
					case VariableTypes.U64:
						opCopy = OpCode.CopyU64;
						break;
					case VariableTypes.Char:
						opCopy = OpCode.CopyChar; 
						break;
					case VariableTypes.String:
						opCopy = OpCode.CopyString; 
						break;
				}
				Emit(opCopy, temp, val);
				AddMappedVar(conj.Name, temp);
			}

			return conj.Name;
		}
	}
}
