using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		private Dictionary<ExpressionTypes, Func<Expression, string>> _handlerMap = new();

		public void SetupHandlerMap()
		{
			_handlerMap.Clear();
			_handlerMap[ExpressionTypes.Scope] = LowerScope;
			_handlerMap[ExpressionTypes.NumberLiteral] = LowerNumberLiteral;
			_handlerMap[ExpressionTypes.StringLiteral] = LowerStringLiteral;
			_handlerMap[ExpressionTypes.BinaryOp] = LowerBinaryOperation;
			_handlerMap[ExpressionTypes.UnaryOp] = LowerUnaryOperation;
			_handlerMap[ExpressionTypes.Parenthesized] = LowerParenthesized;
			_handlerMap[ExpressionTypes.NamedType] = LowerNamedType;
			_handlerMap[ExpressionTypes.Assignment] = LowerAssignment;
			_handlerMap[ExpressionTypes.VariableConjuration] = LowerVariableConjuration;
			_handlerMap[ExpressionTypes.IfStatement] = LowerIfStatement;
			_handlerMap[ExpressionTypes.WhileStatement] = LowerWhileStatement;
			_handlerMap[ExpressionTypes.ForStatement] = LowerForStatement;
			_handlerMap[ExpressionTypes.FunctionDeclaration] = LowerFunctionDeclaration;
			_handlerMap[ExpressionTypes.FunctionInvokation] = LowerFunctionInvokation;
			_handlerMap[ExpressionTypes.Return] = LowerReturn;
			_handlerMap[ExpressionTypes.Whisper] = LowerWhisper;
		}
	}
}
