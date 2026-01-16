using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Common
{
	public enum VariableTypes
	{
		Unknown = 0,
		Void = 1,
		//Bool = 2,
		U64 = 3,
		//I64 = 4,
		Char = 5, 
		String = 6,
	}

	public enum VariableFlags
	{
		Unknown = 0,
		//Nullable = 1,
		UnknownType = 1,
		Volitile = 2,
		Constant = 3,
	}

	public sealed class Variable
	{
		public string Name { get; private set; }
		public VariableTypes Type { get; private set; }
		public VariableFlags Flag { get; private set; }

		private uint _uValue = 0;
		private char _cValue = ' ';

		public Variable(string name, VariableTypes type, VariableFlags flag)
		{
			Name = name;
			Type = type;
			Flag = flag;
		}

		public uint Size()
		{
			switch (Type)
			{
				default:	
					throw new HexException($"Variable type '{Type}' doesn't have an entry for size information.");
				case VariableTypes.Void:
					return 0;
				case VariableTypes.U64:
					return 8;
			}
		}

		public uint U64()
		{
			if (Type != VariableTypes.U64)
				throw new InvalidCastException($"{Name} is type {Type}!");

			return _uValue;
		}

		public char U8()
		{
			if (Type != VariableTypes.Char)
				throw new InvalidCastException($"{Name} is type {Type}!");

			return _cValue;
		}

		public void SetValue(uint uValue)
		{
			_uValue = uValue; 
		}

		public void SetValue(char cValue)
		{
			_cValue = cValue;
		}
	}
}
