
namespace Hex.App
{
	public sealed partial class App
	{
		public int Run(string[] args)
		{
			Init();
			ParseParams(args);
			if (_cmd == kCmd_Execute)
			{
				Cast();
				return 0;
			}

			Console.WriteLine("hex");
			Console.WriteLine("");
			switch (_cmd)
			{
				default:
				case kCmd_PrintUsage:
					PrintUsage();
					break;

				case kCmd_Version:
					PrintVersion();
					break;

				case kCmd_REPL:
					RunRepl();
					break;

				case kCmd_Convert:
					Convert();
					break;
			}

			return 0;
		}
	}
}
