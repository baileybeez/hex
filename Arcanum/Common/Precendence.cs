
namespace Hex.Arcanum.Common
{
	public sealed class Precendence
	{
		public const int kDefault = 0;

		private static readonly Dictionary<LexemeTypes, int> _unary = new()
		{
			{ LexemeTypes.Amplify, 6 },
			{ LexemeTypes.Diminish, 6 },
			{ LexemeTypes.Bang, 6 }
		};

		private static readonly Dictionary<LexemeTypes, int> _binary = new()
		{
			{ LexemeTypes.Times, 5 },
			{ LexemeTypes.Slash, 5 },
			{ LexemeTypes.Percent, 5 },

			{ LexemeTypes.Plus, 4 },
			{ LexemeTypes.Minus, 4 },

			{ LexemeTypes.Equality, 3 },
			{ LexemeTypes.Inequality, 3 },
			{ LexemeTypes.GreaterThan, 3 },
			{ LexemeTypes.GreaterThanEquals, 3 },
			{ LexemeTypes.LessThan, 3 },
			{ LexemeTypes.LessThanEquals, 3 },
			{ LexemeTypes.LogicalAnd, 2 },
			{ LexemeTypes.LogicalOr, 1 },
      };

		public static int GetUnary(LexemeTypes type)
		{
			if (_unary.ContainsKey(type))
				return _unary[type];

			return kDefault;
		}

		public static int GetBinary(LexemeTypes type)
		{
			if (_binary.ContainsKey(type))
				return _binary[type];

			return kDefault;
		}
	}
}
