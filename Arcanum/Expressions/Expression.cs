
using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
	public abstract class Expression
	{
		public ExpressionTypes Type { get; private set; }

		public Expression(ExpressionTypes type)
		{
			Type = type; 
		}
	}
}
