
namespace Hex.App
{
	public sealed partial class App
	{
		public const string kCmd_PrintUsage = "help";
		public const string kCmd_Version = "recension";
		public const string kCmd_Convert = "inscribe";
		public const string kCmd_Compile = "bind";
		public const string kCmd_Execute = "invoke";
		public const string kCmd_REPL = "inkwell";

		public const string kFlag_Output = "-o";

		private string _cmd = kCmd_PrintUsage;
		private string _input = "";
		private string _output = "";

		public void ParseParams(string[] args)
		{
			for (int idx = 0; idx < args.Length; idx++)
			{
				string arg = args[idx];
				switch (arg)
				{
					default:
						_input = arg;
						break;

					case kFlag_Output:
						_output = args[++idx];
						break;

					case kCmd_PrintUsage: 
					case kCmd_Version:
					case kCmd_Convert:
					case kCmd_Compile:
					case kCmd_Execute:
					case kCmd_REPL:
						_cmd = arg;
						break;
				}
			}
		}
	}
}
