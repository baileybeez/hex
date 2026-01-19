
using Hex.Arcanum.Allocator;
using Hex.Arcanum.Common;
using Hex.Arcanum.Emulator;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.Inscriber;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace Hex.App
{
	public sealed partial class App
	{
		public void Invoke()
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
				var emulator = new Emulator(EmulatorMemMode.Raw);

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
			var allocator = new RegisterAllocator();

			var src = File.ReadAllText(_input).Replace("\\n", "\n");
			var lexList = lexer.Run(src);
			var scope = parse.Run(lexList);
			if (scope.Children.Any(c => c.Type != ExpressionTypes.FunctionDeclaration))
				throw new HexException("Commands must be contained within rituals.");

			var program = new List<IRInst>();
			var fncList = scope.Children.Select(c => c as FunctionDeclaration);
			var entry = fncList.FirstOrDefault(f => f != null && f.IsEntryPoint);
			if (entry == null)
				throw new HexException("Entry point not defined!");

			program.Add(new IRInst(OpCode.Call, string.Empty, $"func_{entry.FunctionName}", null));
			program.Add(new IRInst(OpCode.Exit, string.Empty, null, null));
			foreach (var fnc in fncList)
			{
				if (fnc == null)
					throw new HexException("Failed to properly acquire ritual definition.");

				var irList = lower.RunOnRitual(fnc);
				var ranges = allocator.ComputeLiveRanges(irList);
				var result = allocator.AllocateRegisters(ranges);
				var upList = allocator.ProcessAllocations(irList, result);

				program.AddRange(upList);
			}

			return program;
		}
	}
}