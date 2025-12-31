using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public const string kMissingRetVal = "(no return value)";

		// TODO: this needs to be part of the callstack object so we can recursive/nest call functions
		private readonly Dictionary<string, string> _paramMap = new();

		public string LowerScope(Expression expr)
		{
			var scope = AssertValid<Scope>(expr);
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

			_paramMap.Clear();
			return retval;
		}
	}
}
