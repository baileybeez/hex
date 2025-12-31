
namespace Hex.Arcanum.Common
{
	public enum VariableTypes
	{
		Unknown = 0,
		Void = 1,
		//Bool = 2,
		U64 = 3,
		//I64 = 4,
		//String = 5
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

		public Variable(string name, VariableTypes type, VariableFlags flag)
		{
			Name = name;
			Type = type;
			Flag = flag;
		}

		public uint U64()
		{
			if (Type != VariableTypes.U64)
				throw new InvalidCastException($"{Name} is type {Type}!");

			return _uValue;
		}

		public void SetValue(uint uValue)
		{
			_uValue = uValue; 
		}
	}
}
