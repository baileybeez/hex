
namespace Hex.Arcanum.Expressions
{
	public sealed class NamedStatement : Expression
	{
		public string Name { get; private set; }

		public NamedStatement(string name)
			: base(Common.ExpressionTypes.NamedType)
		{
			this.Name = name; 
		}
	}
}
