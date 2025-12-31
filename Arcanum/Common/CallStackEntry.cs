namespace Hex.Arcanum.Common
{
	public sealed class CallStackEntry
	{
		public int ReturnIP { get; private set; }
		public Dictionary<string, string> ParamMap { get; private set; } = new();
		public string ReturnVar { get; set; }

		public CallStackEntry(int ip, string retVar)
		{
			ReturnIP = ip;
			ReturnVar = retVar;
		}
	}
}
