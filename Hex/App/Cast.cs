
using Hex.Arcanum.Emulator;
using Hex.Arcanum.Inscriber;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace Hex.App
{
	public sealed partial class App
	{
		public void Cast()
		{
			if (String.IsNullOrEmpty(_input) || !File.Exists(_input))
			{
				Console.WriteLine("Please provide a valid input file");
				return;
			}

			try
			{
				string src = File.ReadAllText(_input).Replace("\\n", "\n");

				var console = new StandardConsole();
				var lexer = new Lexer();
				var parse = new Parser();
				var lower = new IRLowerer();
				var emulator = new Emulator();

				var lexList = lexer.Run(src);
				var scope = parse.Run(lexList);
				var irList = lower.Run(scope);
				var entryPoint = scope.FindEntryPoint();

				emulator.SetConsole(console);
				emulator.Reset();
				emulator.Run(irList, entryPoint?.FunctionName);
				console.Flush();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}