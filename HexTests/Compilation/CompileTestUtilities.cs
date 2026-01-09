
using Hex.Arcanum.Allocator;
using Hex.Arcanum.Common;
using Hex.Arcanum.Compiler;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace HexTests.Compilation
{
	public class CompileTestUtilities
	{
		public List<string> CompileFrom(string src)
		{
			var irList = ProcessToIRList(src);

			var compiler = new Compiler(Platform.Linux);
			return compiler.Run(irList);
		}

		public List<IRInst> ProcessToIRList(string src)
		{ 
			var lexer = new Lexer();
			var parser = new Parser();
			var lower = new IRLowerer();
			var allocator = new RegisterAllocator();

			var lexList = lexer.Run(src);
			var scope = parser.Run(lexList);
			var fncList = scope.Children.Select(c => c as FunctionDeclaration);

			var program = new List<IRInst>();
			var entry = fncList.FirstOrDefault(f => f != null && f.IsEntryPoint);
			if (entry != null)
			{
				program.Add(new IRInst(OpCode.Call, string.Empty, $"func_{entry.FunctionName}", null));
				program.Add(new IRInst(OpCode.Exit, string.Empty, null, null));
			}

			foreach (var fnc in fncList)
			{
				Assert.That(fnc, Is.Not.Null);

				var irList = lower.RunOnRitual(fnc);

				allocator.Reset();
				var ranges = allocator.ComputeLiveRanges(irList);
				var result = allocator.AllocateRegisters(ranges);

				var upList = allocator.ProcessAllocations(irList, result);

				Assert.That(upList.Count, Is.EqualTo(irList.Count));
				program.AddRange(upList);
			}

			return program;
		}
	}
}
