
using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		private readonly Stack<Scope> _scopeStack = new();
		private readonly List<Lexeme> _lexList = new();
		private int _pos = 0;

		public Parser() 
		{
			SetupHandlerMap();
			SetupVariableTypeMap();
			SetupVariableFlagMap();
		}

		public Scope Run(List<Lexeme> lexList)
		{
			Scope root = new Scope(null, ScopeTypes.Global);

			_pos = 0;
			_lexList.Clear();
			_lexList.AddRange(lexList);
			_scopeStack.Clear();
			_scopeStack.Push(root);
			while (Peek().Type != LexemeTypes.EOF)
			{
				Expression? expr = ParseExpression();
				if (expr != null)
					root.AddExpression(expr);
			}
			_scopeStack.Pop();
			if (_scopeStack.Count > 0)
				throw new HexException("Parser completed work without resolving all scopes!");

			return root;
		}
	}
}
