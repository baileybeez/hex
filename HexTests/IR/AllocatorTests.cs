using Hex.Arcanum.Allocator;
using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace HexTests.IR
{
	public class AllocatorTests 
	{
		Lexer _lexer = new();
		Parser _parser = new();
		IRLowerer _lower = new();
		RegisterAllocator _alloc = new();

		[SetUp] 
		public void Prep()
		{
			_alloc.Reset();
		}

		public void AssertRange(LiveRange range, string varName, int si, int ei)
		{
			Assert.That(range.VarName, Is.EqualTo(varName));
			Assert.That(range.StartIdx, Is.EqualTo(si));
			Assert.That(range.EndIdx, Is.EqualTo(ei));
		}

		[Test]
		public void CalcLiveRanges()
		{
			var lexList = _lexer.Run(Constants.Programs.kFibonacci);
			var scope = _parser.Run(lexList);

			var ritualList = scope.Children
										 .Where(c => c.Type == ExpressionTypes.FunctionDeclaration)
										 .Select(c => c as FunctionDeclaration).ToList();

			Assert.That(ritualList.Count, Is.EqualTo(2));

			var fiboRitual = ritualList.FirstOrDefault(r => r != null && r.FunctionName == "ᚠᛇᛒ");
			Assert.That(fiboRitual, Is.Not.Null);

			var irList = _lower.RunOnRitual(fiboRitual);
			var rangeList = _alloc.ComputeLiveRanges(irList);

			Assert.That(rangeList, Is.Not.Null);
			Assert.That(rangeList.Count, Is.EqualTo(11));
			AssertRange(rangeList[0], "t0", 2, 7);
			AssertRange(rangeList[1], "t1", 3, 4);
			AssertRange(rangeList[2], "ᚫ", 4, 17);
			AssertRange(rangeList[3], "t2", 5, 6);
			AssertRange(rangeList[4], "ᛒ", 6, 16);
			AssertRange(rangeList[5], "ᚲᛸᚲᛚᛖ", 7, 20);
			AssertRange(rangeList[6], "t3", 10, 11);
			AssertRange(rangeList[7], "t4", 11, 12);
			AssertRange(rangeList[8], "t5", 13, 14);
			AssertRange(rangeList[9], "ᚲ", 14, 16);
			AssertRange(rangeList[10], "t6", 19, 20);
		}

		[Test] 
		public void RegAssignment()
		{
			var lexList = _lexer.Run(Constants.Programs.kFibonacci);
			var scope = _parser.Run(lexList);

			var ritualList = scope.Children
										 .Where(c => c.Type == ExpressionTypes.FunctionDeclaration)
										 .Select(c => c as FunctionDeclaration).ToList();

			Assert.That(ritualList.Count, Is.EqualTo(2));

			var fiboRitual = ritualList.FirstOrDefault(r => r != null && r.FunctionName == "ᚠᛇᛒ");
			Assert.That(fiboRitual, Is.Not.Null);

			var irList = _lower.RunOnRitual(fiboRitual);
			var rangeList = _alloc.ComputeLiveRanges(irList);
			var results = _alloc.AllocateRegisters(rangeList);

			Assert.That(results, Is.Not.Null);
			Assert.That(results.UsedCalleeList.Count, Is.EqualTo(0));
			Assert.That(results.UsedStackSize, Is.EqualTo(0));
			Assert.That(results.RangeList.Count, Is.EqualTo(rangeList.Count));
			Assert.That(results.RangeList[0].AssignedReg, Is.EqualTo(Registers.R11));
			Assert.That(results.RangeList[1].AssignedReg, Is.EqualTo(Registers.R10));
			Assert.That(results.RangeList[2].AssignedReg, Is.EqualTo(Registers.R9));
			Assert.That(results.RangeList[3].AssignedReg, Is.EqualTo(Registers.R10));
			Assert.That(results.RangeList[4].AssignedReg, Is.EqualTo(Registers.R8));
			Assert.That(results.RangeList[5].AssignedReg, Is.EqualTo(Registers.R10));
			Assert.That(results.RangeList[6].AssignedReg, Is.EqualTo(Registers.R11));
			Assert.That(results.RangeList[7].AssignedReg, Is.EqualTo(Registers.RCX));
			Assert.That(results.RangeList[8].AssignedReg, Is.EqualTo(Registers.R11));
			Assert.That(results.RangeList[9].AssignedReg, Is.EqualTo(Registers.RCX));
			Assert.That(results.RangeList[10].AssignedReg, Is.EqualTo(Registers.R11));
		}

		[Test]
		public void RegisterAllocation()
		{
			var lexList = _lexer.Run(Constants.Programs.kFibonacci);
			var scope = _parser.Run(lexList);

			var ritualList = scope.Children
										 .Where(c => c.Type == ExpressionTypes.FunctionDeclaration)
										 .Select(c => c as FunctionDeclaration).ToList();

			Assert.That(ritualList.Count, Is.EqualTo(2));

			var fiboRitual = ritualList.FirstOrDefault(r => r != null && r.FunctionName == "ᚠᛇᛒ");
			Assert.That(fiboRitual, Is.Not.Null);

			var irList = _lower.RunOnRitual(fiboRitual);
			var rangeList = _alloc.ComputeLiveRanges(irList);
			var results = _alloc.AllocateRegisters(rangeList);
			var finalizedIr = _alloc.ProcessAllocations(irList, results);

			Assert.That(finalizedIr, Is.Not.Null);
			Assert.That(finalizedIr.Count, Is.EqualTo(irList.Count));
			Assert.That(finalizedIr[2].result, Is.EqualTo("R11"));
			Assert.That(finalizedIr[3].result, Is.EqualTo("R10"));
			Assert.That(finalizedIr[4].result, Is.EqualTo("R9"));
			Assert.That(finalizedIr[5].result, Is.EqualTo("R10"));
			Assert.That(finalizedIr[6].result, Is.EqualTo("R8"));
			Assert.That(finalizedIr[7].result, Is.EqualTo("R10"));
			Assert.That(finalizedIr[10].result, Is.EqualTo("R11"));
			Assert.That(finalizedIr[11].result, Is.EqualTo("RCX"));
			Assert.That(finalizedIr[12].result, Is.EqualTo("RCX"));
			Assert.That(finalizedIr[13].result, Is.EqualTo("R11"));
			Assert.That(finalizedIr[14].result, Is.EqualTo("RCX"));
			Assert.That(finalizedIr[15].result, Is.EqualTo("R9"));
			Assert.That(finalizedIr[16].result, Is.EqualTo("R8"));
			Assert.That(finalizedIr[19].result, Is.EqualTo("R11"));
			Assert.That(finalizedIr[20].result, Is.EqualTo("R10"));
		}
	}
}
