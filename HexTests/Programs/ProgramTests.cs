using Hex.Arcanum.Allocator;
using Hex.Arcanum.Common;
using Hex.Arcanum.Emulator;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;
using HexTests.Emulation;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace HexTests.Programs
{
	public class ProgramTests : EmulateTestUtilities
	{
		[Test]
		public void SimpleAdd()
		{
			TestConsole con = new();
			Emulate(Constants.kRitual_Add_Call, EmulatorMemMode.Mapped, con);

			Assert.That(con.Logs.Count, Is.EqualTo(1));
			Assert.That(con.Logs[0], Is.EqualTo("5"));
		}

		[Test]
		public void Fibonacci()
		{
			TestConsole con = new();
			Emulate(Constants.Programs.kFibonacci, EmulatorMemMode.Mapped, con);

			Assert.That(con.Logs.Count, Is.EqualTo(11));
			Assert.That(con.Logs[0], Is.EqualTo("1"));
			Assert.That(con.Logs[4], Is.EqualTo("5"));
			Assert.That(con.Logs[7], Is.EqualTo("21"));
			Assert.That(con.Logs[10], Is.EqualTo("89"));
		}

		[Test]
		public void FizzBuzz()
		{
			TestConsole con = new();
			Emulate(Constants.Programs.kFizzBuzz, EmulatorMemMode.Mapped, con);

			Assert.That(con.Logs.Count, Is.EqualTo(50));
			Assert.That(con.Logs[1], Is.EqualTo("2"));
			Assert.That(con.Logs[2], Is.EqualTo("fizz"));
			Assert.That(con.Logs[4], Is.EqualTo("buzz"));
			Assert.That(con.Logs[10], Is.EqualTo("11"));
			Assert.That(con.Logs[14], Is.EqualTo("fizzbuzz"));
		}

		[Test]
		public void FibonacciWithRegAllocation()
		{
			TestConsole console = new();

			var lexer = new Lexer();
			var parse = new Parser();
			var lower = new IRLowerer();
			var allocator = new RegisterAllocator();

			var lexList = lexer.Run(Constants.Programs.kFibonacci);
			var scope = parse.Run(lexList);
			var fncList = scope.Children.Select(c => c as FunctionDeclaration);

			var program = new List<IRInst>();
			var entry = fncList.FirstOrDefault(f => f != null && f.IsEntryPoint);
			Assert.That(entry, Is.Not.Null);

			program.Add(new IRInst(OpCode.Call, string.Empty, $"func_{entry.FunctionName}", null));
			program.Add(new IRInst(OpCode.Exit, string.Empty, null, null));
			foreach (var fnc in fncList)
			{
				Assert.That(fnc, Is.Not.Null);

				var irList = lower.RunOnRitual(fnc);
				var ranges = allocator.ComputeLiveRanges(irList);
				var result = allocator.AllocateRegisters(ranges);

				var upList = allocator.ProcessAllocations(irList, result);

				Assert.That(upList.Count, Is.EqualTo(irList.Count));
				program.AddRange(upList);
			}

			_emu = new Emulator(EmulatorMemMode.Raw);
			_emu.SetConsole(console);
			_emu.Reset();
			_emu.Run(program);
			if (console != null)
				console.Flush();

			Assert.That(console, Is.Not.Null);
			Assert.That(console.Logs.Count, Is.EqualTo(11));
			Assert.That(console.Logs[0], Is.EqualTo("1"));
			Assert.That(console.Logs[4], Is.EqualTo("5"));
			Assert.That(console.Logs[7], Is.EqualTo("21"));
			Assert.That(console.Logs[10], Is.EqualTo("89"));
		}

		[Test]
		public void Factorial()
		{
			TestConsole console = new();
			var program = CompileToIR(Constants.Programs.kFactorial);

			_emu = new Emulator(EmulatorMemMode.Raw);
			_emu.SetConsole(console);
			_emu.Reset();
			_emu.Run(program);
			if (console != null)
				console.Flush();

			Assert.That(console, Is.Not.Null);
			Assert.That(console.Logs.Count, Is.EqualTo(1));
			Assert.That(console.Logs[0], Is.EqualTo("Factorial of 12 is 479001600.\\n"));
		}

		[Test]
		public void StringLen()
		{
			TestConsole console = new();
			var program = CompileToIR(Constants.Programs.kStrLen);

			_emu = new Emulator(EmulatorMemMode.Raw);
			_emu.SetConsole(console);
			_emu.Reset();
			_emu.Run(program);
			if (console != null)
				console.Flush();

			Assert.That(console, Is.Not.Null);
			Assert.That(_emu.GetU64("RBX"), Is.EqualTo(11));
		}
	}
}
