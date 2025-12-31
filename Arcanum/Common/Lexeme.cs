namespace Hex.Arcanum.Common
{
	public sealed record Lexeme (LexemeTypes Type, string Text, int LineNo, int Col);
}
