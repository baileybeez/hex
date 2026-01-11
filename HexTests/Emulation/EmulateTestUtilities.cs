using Hex.Arcanum.Allocator;
using Hex.Arcanum.Common;
using Hex.Arcanum.Emulator;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.Interfaces;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace HexTests.Emulation
{
	public class EmulateTestUtilities
	{
		protected Emulator _emu = new Emulator();

		public void Emulate(string src, IConsole? console = null)
		{
			var lexer = new Lexer();
			var parse = new Parser();
			var lower = new IRLowerer();

			var lexList = lexer.Run(src);
			var scope = parse.Run(lexList);
			var irList = lower.Run(scope);

			_emu.SetConsole(console);
			_emu.Reset();
			_emu.Run(irList);
			if (console != null)
				console.Flush();
		}

		public UInt64 U64Val(string name)
		{
			return _emu.GetU64(_emu.GetValue(name));
		}

		public List<IRInst> CompileToIR(string src)
		{

			var lexer = new Lexer();
			var parse = new Parser();
			var lower = new IRLowerer();
			var allocator = new RegisterAllocator();

			var lexList = lexer.Run(src);
			var scope = parse.Run(lexList);
			var fncList = scope.Children.Select(c => c as FunctionDeclaration);

			var program = new List<IRInst>();
			var entry = fncList.FirstOrDefault(f => f != null && f.IsEntryPoint);

			program.Add(new IRInst(OpCode.Call, string.Empty, $"func_{entry.FunctionName}", null));
			program.Add(new IRInst(OpCode.Exit, string.Empty, null, null));
			foreach (var fnc in fncList)
			{
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
