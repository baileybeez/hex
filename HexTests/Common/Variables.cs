using Hex.Arcanum.Common;

namespace HexTests.Common
{
	public class Variables
	{
		[Test]
		public void U64()
		{
			const uint val = 1234;
			Variable v = new Variable("test", VariableTypes.U64, VariableFlags.Volitile);
			v.SetValue(val);

			Assert.That(v.U64(), Is.EqualTo(val));
		}
	}
}
