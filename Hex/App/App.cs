
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
				Invoke();
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

				case kCmd_Compile:
					Compile();
					break;
			}

			return 0;
		}
	}
}
