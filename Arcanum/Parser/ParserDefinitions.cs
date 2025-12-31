using Hex.Arcanum.Common;

namespace Hex.Arcanum.Parser
{
	public sealed partial class Parser
	{
		private static readonly Lexeme kEndOfFileLexeme = new Lexeme(LexemeTypes.EOF, "\0", 0, 0);

		private readonly Dictionary<LexemeTypes, VariableTypes> _varTypeMap = new();
		private readonly Dictionary<LexemeTypes, VariableFlags> _varFlagsMap = new();

		private void SetupVariableTypeMap()
		{
			_varTypeMap.Add(LexemeTypes.Ash, VariableTypes.Void);
			_varTypeMap.Add(LexemeTypes.Salt, VariableTypes.U64);
		}

		private void SetupVariableFlagMap()
		{
			//_varFlagsMap.Add(TokenTypes.Aether, VariableFlags.Nullable);
			_varFlagsMap.Add(LexemeTypes.Air, VariableFlags.UnknownType);
			_varFlagsMap.Add(LexemeTypes.Fire, VariableFlags.Volitile);
			_varFlagsMap.Add(LexemeTypes.Earth, VariableFlags.Constant);
		}
	}
}