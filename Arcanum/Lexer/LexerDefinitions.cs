
using Hex.Arcanum.Common;
using System.Text;

namespace Hex.Arcanum.Lexer
{
	public sealed partial class Lexer
	{
		public const int kState_Idle = 0;
		public const int kState_Number = 1;
		public const int kState_Identifier = 2;
		public const int kState_String = 3;

		private static readonly Rune kEmptyRune = new Rune(' ');
		private static readonly Rune kDoubleQuote = new Rune('\"');
		private static readonly Rune kNewLineRune = new Rune('\n');

		private static readonly string kNewLine = "\n";

		private readonly static Rune[] _numberList = new Rune[10] {
			new Rune('0'), new Rune('1'), new Rune('2'), new Rune('3'), new Rune('4'),
			new Rune('5'), new Rune('6'), new Rune('7'), new Rune('8'), new Rune('9')
		};

		private readonly static Rune[] _runeList = new Rune[26] {
			new Rune(0x16AB), new Rune(0x16D2), new Rune(0x16A6), new Rune(0x16DE), new Rune(0x16D6), new Rune(0x16A0),
			new Rune(0x16B7), new Rune(0x16BA), new Rune(0x16C7), new Rune(0x16C3), new Rune(0x16B2), new Rune(0x16DA),
			new Rune(0x16D7), new Rune(0x16BE), new Rune(0x16DF), new Rune(0x16C8), new Rune(0x16F0), new Rune(0x16B1),
			new Rune(0x16CA), new Rune(0x16CF), new Rune(0x16A2), new Rune(0x16B9), new Rune(0x16DD), new Rune(0x16AF),
			new Rune(0x16F8), new Rune(0x16C9)
		};

		private static readonly Dictionary<int, LexemeTypes> _symbolMap = new()
		{
			{ RuneCodes.Plus, LexemeTypes.Plus },
			{ RuneCodes.Minus, LexemeTypes.Minus },
			{ RuneCodes.Asterisk, LexemeTypes.Times },
			{ RuneCodes.Slash, LexemeTypes.Slash },
			{ RuneCodes.Percent, LexemeTypes.Percent },
			{ RuneCodes.OpenParen, LexemeTypes.OpenParen },
			{ RuneCodes.CloseParen, LexemeTypes.CloseParen },
			{ RuneCodes.SelenaMoon, LexemeTypes.Whisper },

			{ RuneCodes.DoubleUpArrow, LexemeTypes.Amplify },
			{ RuneCodes.DoubleDownArrow, LexemeTypes.Diminish },

			{ RuneCodes.Bang, LexemeTypes.Bang },
			{ RuneCodes.Truth, LexemeTypes.True },
			{ RuneCodes.False, LexemeTypes.False },
			{ RuneCodes.Exists, LexemeTypes.Equality },
			{ RuneCodes.NotExists, LexemeTypes.Inequality },
			{ RuneCodes.GreaterThan, LexemeTypes.GreaterThan },
			{ RuneCodes.GreaterThanEquals, LexemeTypes.GreaterThanEquals },
			{ RuneCodes.LessThan, LexemeTypes.LessThan },
			{ RuneCodes.LessThanEquals, LexemeTypes.LessThanEquals },

			{ RuneCodes.Pentacle, LexemeTypes.Ritual },
			{ RuneCodes.LargeCircle, LexemeTypes.Circle },
			{ RuneCodes.SquareLeftTick, LexemeTypes.CloseScope },
			{ RuneCodes.SquareRightTick, LexemeTypes.OpenScope },
			{ RuneCodes.WaveArrowRight, LexemeTypes.If },
			{ RuneCodes.CWFullArrow, LexemeTypes.While },
			{ RuneCodes.RightLeftArrows, LexemeTypes.Weave },
			{ RuneCodes.DoubleArrowRight, LexemeTypes.To },
			{ RuneCodes.Conjure, LexemeTypes.Conjure },
			{ RuneCodes.Cauldron, LexemeTypes.Cauldron },
			{ RuneCodes.ArrowRight, LexemeTypes.RightArrow },
			{ RuneCodes.ArrowLeft, LexemeTypes.LeftArrow },
			{ RuneCodes.Distill, LexemeTypes.Invoke },
			{ RuneCodes.Trident, LexemeTypes.Return },
			{ RuneCodes.ItalicPhi, LexemeTypes.EntryPoint },

			{ RuneCodes.Tartar, LexemeTypes.Place },
			{ RuneCodes.CWSemiArrow, LexemeTypes.StirCW },
			{ RuneCodes.CCWSemiArrow, LexemeTypes.StirCCW },

			{ RuneCodes.Air, LexemeTypes.Air },
			{ RuneCodes.Fire, LexemeTypes.Fire },
			{ RuneCodes.Earth, LexemeTypes.Earth },
			{ RuneCodes.Water, LexemeTypes.Water  },

			{ RuneCodes.Salt, LexemeTypes.Salt },
			{ RuneCodes.Ash, LexemeTypes.Ash },
		};

		public static bool IsIdentifier(string str)
		{
			var runeList = str.EnumerateRunes();
			foreach (var rune in runeList)
			{
				if (!Lexer.IsRune(rune))
					return false;
			}

			return true;
		}

		public static bool IsNumber(Rune rune) => _numberList.Contains(rune);
		public static bool IsRune(Rune rune) => _runeList.Contains(rune);
	}
}