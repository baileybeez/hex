
namespace Hex.Arcanum.Common
{
	public enum StirDirection
	{
		Clockwise = 1,
		CounterClockwise = 2,
	}

	public sealed class FunctionParam
    {
		public string Name { get; private set; }
		public VariableTypes Type { get; private set; }
		public VariableFlags Flag { get; private set; }
		public StirDirection Stir { get; private set; }
		public string Location { get; set; } = String.Empty;

		public FunctionParam(string name, VariableTypes type, VariableFlags flag, StirDirection dir)
		{
			Name = name;
			Type = type;
			Flag = flag;
			Stir = dir;
		}
	}
}
