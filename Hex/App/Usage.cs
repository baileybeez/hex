
namespace Hex.App
{
	public sealed partial class App
	{
		public void PrintUsage()
		{
			Console.WriteLine("Usage: hex [command] [options]");
			Console.WriteLine("");
			Console.WriteLine("help          :: displays this information");
			Console.WriteLine("recension     :: reports version information");
			Console.WriteLine("inscribe [in] :: converts supplied vellum to codex file");
			Console.WriteLine("invoke [in]   :: executes the provided codex file in the emulator");
			Console.WriteLine("inkwell       :: starts the REPL");
		}
	}
}