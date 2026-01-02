
using Hex.Arcanum.Common;
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
				List<IRInst> irList = ProcessInputFile();
				var console = new StandardConsole();
				var emulator = new Emulator();

				emulator.SetConsole(console);
				emulator.Reset();
				emulator.Run(irList);
				console.Flush();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public List<IRInst> ProcessInputFile()
		{
			string ext = Path.GetExtension(_input);
			switch (ext)
			{
				default:
					throw new Exception("Invalid input file provided.");
				case ".codex":
					return CompileFromFile();
				case ".ir":
					return IRFile.Load(_input);
			}
		}

		public List<IRInst> CompileFromFile()
		{
			var lexer = new Lexer();
			var parse = new Parser();
			var lower = new IRLowerer();

			var src = File.ReadAllText(_input).Replace("\\n", "\n");
			var lexList = lexer.Run(src);
			var scope = parse.Run(lexList);
			
			return lower.Run(scope);
		}
	}
}