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

			string temp = NewTemp();
			string? val = null;
			if (conj.InitialValue != null)
			{
				val = LowerExpression(conj.InitialValue);
				Emit(OpCode.Copy, temp, val);
				AddVar(conj.Name, temp);
			}

			return conj.Name;
		}
	}
}
