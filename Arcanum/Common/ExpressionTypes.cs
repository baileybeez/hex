
namespace Hex.Arcanum.Common
{
	public enum ExpressionTypes
	{
		Unknown = 0,

		UnaryOp = 1, 
		BinaryOp = 2,
		Scope = 3,
		Parenthesized = 4,
		NamedType = 5, 
		Assignment = 6,
		Whisper = 7,

		NumberLiteral = 10,
		BooleanLiteral = 11,

		VariableConjuration = 20,
		IfStatement = 21,
		WhileStatement = 22,
		ForStatement = 23,

		FunctionDeclaration = 24,
		FunctionInvokation = 25,
		Return = 26,
	}
}