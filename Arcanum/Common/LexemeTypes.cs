
namespace Hex.Arcanum.Common
{
	public enum LexemeTypes
	{
		// baseline
		Unknown = 0,
		Keyword = 1,
		Identifier = 2,
		Symbol = 3,
		Number = 4,
		String = 5,
		NewLine = 6,
		EOF = 7,
		Whisper = 8,

		// arithmetic
		Plus = 10,
		Minus = 11,
		Times = 12,
		Slash = 13,
		Percent = 14,
		OpenParen = 15,
		CloseParen = 16,
		Bang = 17,
		Amplify = 18,
		Diminish = 19,

		// logic
		True = 20,
		False = 21,
		Equality = 22,
		Inequality = 23,
		GreaterThan = 24,
		LessThan = 25,
		GreaterThanEquals = 26,
		LessThanEquals = 27,

		// arcane 
		Ritual = 40,
		Circle = 41,
		OpenScope = 42,
		CloseScope = 43,
		Conjure = 44,
		Cauldron = 45,
		StirCW = 46,
		StirCCW = 47,
		RightArrow = 48,
		LeftArrow = 49,

		While = 53,
		If = 54,
		Weave = 55,
		To = 56,

		Place = 60,
		Invoke = 61,
		Return = 62,

		EntryPoint = 77,

		// elements
		Aether = 91,
		Air = 92,
		Fire = 93,
		Earth = 94,
		Water = 95,

		// var types
		Salt = 100,
		Ash = 101,
	}
}
