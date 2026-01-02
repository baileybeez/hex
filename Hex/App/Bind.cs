
using Hex.Arcanum.Common;
using Hex.Arcanum.Emulator;
using Hex.Arcanum.Inscriber;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Hex.App
{
	public sealed partial class App
	{
		public void Compile()
		{
			if (String.IsNullOrEmpty(_input) || !File.Exists(_input))
			{
				Console.WriteLine("Please provide a valid input file");
				return;
			}

			if (String.IsNullOrEmpty(_output))
				_output = Path.GetFileNameWithoutExtension(_input) + ".ir";

			try
			{
				string src = File.ReadAllText(_input).Replace("\\n", "\n");

				var console = new StandardConsole();
				var lexer = new Lexer();
				var parse = new Parser();
				var lower = new IRLowerer();
				
				var lexList = lexer.Run(src);
				var scope = parse.Run(lexList);
				var irList = lower.Run(scope);

				IRFile.Save(_output, irList);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}