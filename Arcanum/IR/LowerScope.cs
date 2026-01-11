using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public const string kMissingRetVal = "(no return value)";

		public string LowerScope(Expression expr)
		{
			var scope = AssertValid<Scope>(expr);
			var curr = PushScope();

			string retval = kMissingRetVal;
			for (int i = 0; i < scope.Children.Count; i++)
			{
				var child = scope.Children.ElementAt(i);
				string str = LowerExpression(child);
				if (child.Type == ExpressionTypes.Return)
					retval = str;
				else
					retval = kMissingRetVal;
			}

			PopScope();
			return retval;
		}
	}
}
