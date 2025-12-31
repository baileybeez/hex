using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace HexTests.IR
{
	public class LowerTestUtilities
	{
		Lexer _lexer = new();
		Parser _parser = new();
		IRLowerer _lower = new();

		public Scope Parse(string str)
		{
			var tokens = _lexer.Run(str);
			var parser = new Parser();

			return parser.Run(tokens);
		}

		public List<IRInst> Lower(string src)
		{
			var tokens = _lexer.Run(src);
			var scope = _parser.Run(tokens);

			_lower.Reset();
			return _lower.Run(scope);
		}
	}
}
