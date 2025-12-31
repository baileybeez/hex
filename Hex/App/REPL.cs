using Hex.Arcanum.Common;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Emulator;
using Hex.Arcanum.IR;
using Hex.Arcanum.Inscriber;

namespace Hex.App
{
	public sealed partial class App
	{
		public const string kOpt_ShowIR = "show-ir";

		private Inscriber? _inscriber;
		private Lexer? _lexer;
		private Parser? _parser;
		private IRLowerer? _lowerer;
		private Emulator? _emu;

		private Dictionary<string, string> _optMap = new();

		public void SetupRepl()
		{
			_inscriber = new();
			_lexer = new Lexer();
			_parser = new Parser();
			_lowerer = new IRLowerer();
			_emu = new Emulator();
		}

		public void RunRepl()
		{
			SetupRepl();

			string? input;
			while (true)
			{
				Console.Write("> ");
				input = Console.ReadLine();
				if (input == null || input == "q" || input == "quit")
					break;
				
				ProcessLine(input);
			}
		}

		public void ProcessLine(string line)
		{
			if (_inscriber == null || _lexer == null ||
				 _parser == null || _lowerer == null || _emu == null)
			{
				return;
			}
			else if (HandleREPLCommand(line))
				return;

			try
			{
				line = _inscriber.Run(line);
				Console.WriteLine(line);
				var lexList = _lexer.Run(line);
				var scope = _parser.Run(lexList);
				var irList = _lowerer.Run(scope);
				if (_optMap.TryGetValue(kOpt_ShowIR, out var opt) && opt == "true")
				{
					foreach (IRInst inst in irList)
						Console.WriteLine($"{inst.opCode} {inst.result} {inst.leftOperand ?? ""} {inst.rightOperand ?? ""}");
				}

				var entryPoint = scope.FindEntryPoint();

				_emu.Run(irList, entryPoint?.FunctionName);
			}
			catch (HexException hex)
			{
				Console.WriteLine(hex.Message);
			}
		}

		public bool HandleREPLCommand(string line)
		{
			if (_emu == null)
				return false;

			if (line == "clear")
			{
				_emu.Reset();
				return true;
			}
			else if (line == "dump")
			{
				_emu.DumpMemory();
				return true;
			}
			else if (line.StartsWith("set-opt"))
			{
				HandleOption(line);
				return true;
			}

			return false; 
		}

		public void HandleOption(string line)
		{
			// set-opt [option] [value]
			string[] parts = line.Split(' ');
			if (parts.Length != 3)
				return;

			_optMap[parts[1]] = parts[2];
		}
	}
}