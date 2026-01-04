
namespace HexTests
{
	public sealed class Constants
	{
		public const string kSimpleScript = "1 + 2";
		public const string kParenScript = "(1 + 2) * 3";

		public const string kAmp = "⇑ᚫ";
		public const string kDim = "⇓ᚫ";

		public const string kEqualityScript = "1 ∃ 2";
		public const string kInequalityScript = "1 ∄ 2";
		public const string kGreaterScript = "1 > 2";
		public const string kGreaterEqScript = "1 ≥ 2";
		public const string kLessScript = "1 < 2";
		public const string kLessEqScript = "1 ≤ 2";
		public const string kBangScript = "!⊥";

		public const string kVarName = "ᚫ";
		public const string kConjureVar = "🝣 🜂 🜔 ᚫ";
		public const string kConjureVarAssign = "🝣 🜃 🜔 ᚫ ← 1";
		public const string kAssignmentScript = "ᚫ ← 1";

		public const string kSimpleIfStatement = "⟥ ↝ ᛖ > 0 \r\n \r\n ⟤ ";
		public const string kSimpleWhileStatement = "⟥ ↻ ᛖ > 0 \r\n \r\n ⟤";
		public const string kSimpleForStatement = "⟥ ⇄ ᛖ 0 ⇒ 10 \r\n \r\n ⟤";

		public const string kRitualDeclaration = "⚝ ᚠᛇᛒ → 🝗\r\n🝣🝥\r\n   🝀 🜃 🜔 ᚷᛖᚾ ↷\r\n◯⟥ \r\n \r\n ⟤ ";
		public const string kRitualDeclarationLargeArgCount = "⚝ ᚠᛇᛒ → 🜔\r\n🝣 🝥\r\n   🝀 🜃 🜔 ᚫ ↷\r\n   🝀 🜃 🜔 ᛒ ↷\r\n   🝀 🜃 🜔 ᚦ ↷\r\n   🝀 🜃 🜔 ᛞ ↷\r\n   🝀 🜃 🜔 ᛖ ↷\r\n   🝀 🜃 🜔 ᚠ ↷\r\n   🝀 🜃 🜔 ᚷ ↷\r\n   🝀 🜃 🜔 ᚺ ↷\r\n◯⟥\r\n⟤ ";
		public const string kRitualInvokation = "🝣🝥\r\n   🝀 ᚷᛖᚾ 🝥 ↷\r\n   🝠 ᚠᛇᛒ";
		public const string kRitualInvokationIntoVar = "🝣🝥\r\n   🝀 ᚷᛖᚾ 🝥 ↷\r\n   🝠 ᚠᛇᛒ ⇒ ᚫ";
		public const string kRitualInvokationLargeArgCount = "🝣 🝥\r\n🝀 1 🝥 ↷\r\n🝀 2 🝥 ↷\r\n🝀 3 🝥 ↷\r\n🝀 4 🝥 ↷\r\n🝀 5 🝥 ↷\r\n🝀 6 🝥 ↷\r\n🝀 7 🝥 ↷\r\n🝀 8 🝥 ↷\r\n🝠 ᚠᛇᛒ ";

		public const string kRitual_Add = "⚝ ᚫᛞᛞ → 🜔\r\n🝣🝥\r\n   🝀 🜂 🜔 ᚫ ↷\r\n   🝀 🜂 🜔 ᛒ ↷\r\n◯⟥\r\n   🝑 ᛒ + ᚫ\r\n⟤ ";
		public const string kRitual_Add_Call = "⚝ ᚫᛞᛞ → 🜔\r\n🝣🝥\r\n   🝀 🜂 🜔 ᚫ ↷\r\n   🝀 🜂 🜔 ᛒ ↷\r\n◯⟥\r\n   🝑 ᛒ + ᚫ\r\n⟤\r\n\r\n𝜙⚝ ᛗᚫᛇᚾ → 🝗\r\n◯⟥\r\n   🝣🝥\r\n   🝀 2 🝥 ↷\r\n   🝀 3 🝥 ↷\r\n   🝠 ᚫᛞᛞ ⇒ ᚫ\r\n   ⯝ ᚫ\r\n⟤\r\n";
		public const string kRitual_NestedCalls = "⚝ ᚠᛟᛟ → 🜔\r\n🝣🝥\r\n◯⟥\r\n   🝑 5\r\n⟤\r\n\r\n⚝ ᚠᛟᛟᚫᛞᛞ → 🜔\r\n🝣🝥\r\n   🝀 🜂 🜔 ᛒ ↷\r\n◯⟥\r\n   🝣 🜂 🜔 ᚫ \r\n   🝣 🝥 🝠 ᚠᛟᛟ ⇒ ᚫ\r\n\r\n   🝑 ᛒ + ᚫ\r\n⟤\r\n\r\n𝜙⚝ ᛗᚫᛇᚾ → 🝗\r\n◯⟥\r\n   🝣 🜂 🜔 ᚫ \r\n   🝣 🜂 🜔 ᛒ ← 4\r\n\r\n   🝣 🝥 🝠 ᚠᛟᛟ ⇒ ᚫ\r\n\r\n   🝣 🝥\r\n   🝀 ᛒ 🝥 ↷\r\n   🝠 ᚠᛟᛟᚫᛞᛞ\r\n⟤ ";

		public const string kConsoleOutput = "⯝ \"hello world\"";
		public const string kStringWithCRLF = "⯝ \"1\n\"";

		public static readonly ProgramListings Programs = new();
	}

	public sealed class ProgramListings
	{
		public readonly string kFibonacci = "⚝ ᚠᛇᛒ → 🜔\r\n🝣 🝥\r\n   🝀 🜃 🜔 ᚷᛖᚾ ↷\r\n◯⟥\r\n   🝣 🜂 🜔 ᚫ ← 1\r\n   🝣 🜂 🜔 ᛒ ← 1\r\n   🝣 🜂 🜔 ᚲ \r\n\r\n   🝣 🜂 🜔 ᚲᛸᚲᛚᛖ ← ᚷᛖᚾ\r\n   \r\n   ⯝ \"1\n\"\r\n   ⟥ ↻ ᚲᛸᚲᛚᛖ > 0 \r\n      ᚲ ← ᛒ + ᚫ\r\n      ᚫ ← ᛒ\r\n      ᛒ ← ᚲ\r\n\r\n      ⯝ ᚫ\r\n      ⯝ \"\n\"\r\n      ⇓ ᚲᛸᚲᛚᛖ\r\n   ⟤\r\n⟤\r\n\r\n𝜙⚝ ᛗᚫᛇᚾ → 🝗\r\n◯⟥\r\n   🝣 🜂 🜔 ᚷᛖᚾ ← 10\r\n\r\n   🝣 🝥\r\n   🝀 ᚷᛖᚾ 🝥 ↷\r\n   🝠 ᚠᛇᛒ\r\n⟤\r\n ";
	}
}
