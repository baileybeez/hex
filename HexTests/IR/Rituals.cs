using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.IR;

namespace HexTests.IR
{
	public class Rituals : LowerTestUtilities
	{
		[Test]
		public void Declaration()
		{
			var opList = new OpCode[] {
				OpCode.Label, 
				OpCode.EnterFunc, 
				OpCode.CopyFromReg, 
				OpCode.LeaveFunc, 
				OpCode.Return 
			};
			var list = Lower(Constants.kRitualDeclaration);

			Assert.That(list.Count, Is.EqualTo(opList.Length));
			for (int idx = 0; idx < opList.Length; idx++)
				Assert.That(list[idx].opCode, Is.EqualTo(opList[idx]));
		}

		[Test]
		public void Invokation()
		{
			var opList = new OpCode[] { 
				OpCode.SetupCall, 
				OpCode.CopyToReg, 
				OpCode.Call 
			};
			var list = Lower(Constants.kRitualInvokation);

			Assert.That(list.Count, Is.EqualTo(opList.Length));
			for (int idx = 0; idx < opList.Length; idx++)
				Assert.That(list[idx].opCode, Is.EqualTo(opList[idx]));
		}

		[Test]
		public void Decl_Add_a_b()
		{
			var opList = new OpCode[] {
				OpCode.Label, 
				OpCode.EnterFunc, 
				OpCode.CopyFromReg, 
				OpCode.CopyFromReg, 
				OpCode.Add,
				OpCode.CopyToReg,
				OpCode.LeaveFunc, 
				OpCode.Return
			};
			var list = Lower(Constants.kRitual_Add);

			Assert.That(list.Count, Is.EqualTo(opList.Length));
			for (int idx = 0; idx < opList.Length; idx++)
				Assert.That(list[idx].opCode, Is.EqualTo(opList[idx]));
		}

		[Test]
		public void Decl_and_Call_Add_a_b()
		{
			var opList = new OpCode[] {
				OpCode.Call,
				OpCode.Exit,
				OpCode.Label,
				OpCode.EnterFunc,
				OpCode.CopyFromReg,
				OpCode.CopyFromReg,
				OpCode.Add,
				OpCode.CopyToReg,
				OpCode.LeaveFunc,
				OpCode.Return,
				OpCode.Label,
				OpCode.EnterFunc,
				OpCode.LoadU64Const, 
				OpCode.LoadU64Const, 
				OpCode.SetupCall,
				OpCode.CopyToReg, 
				OpCode.CopyToReg, 
				OpCode.Call, 
				OpCode.CopyFromReg,
				OpCode.Whisper, 
				OpCode.LeaveFunc, 
				OpCode.Return
			};
			var list = Lower(Constants.kRitual_Add_Call);

			Assert.That(list.Count, Is.EqualTo(opList.Length));
			for (int idx = 0; idx < opList.Length; idx++)
				Assert.That(list[idx].opCode, Is.EqualTo(opList[idx]));
		}

		[Test]
		public void InvokeIntoVariable()
		{
			var opList = new OpCode[] {
				OpCode.SetupCall,
				OpCode.CopyToReg,
				OpCode.Call, 
				OpCode.CopyFromReg
			};
			var list = Lower(Constants.kRitualInvokationIntoVar);

			Assert.That(list.Count, Is.EqualTo(opList.Length));
			for (int idx = 0; idx < opList.Length; idx++)
				Assert.That(list[idx].opCode, Is.EqualTo(opList[idx]));
		}

		[Test]
		public void LargeArgCountFuncCall()
		{
			var opList = new OpCode[] {
				OpCode.LoadU64Const,
				OpCode.LoadU64Const,
				OpCode.LoadU64Const,
				OpCode.LoadU64Const,
				OpCode.LoadU64Const,
				OpCode.LoadU64Const,
				OpCode.LoadU64Const,
				OpCode.LoadU64Const,
				OpCode.SetupCall,
				OpCode.CopyToReg, 
				OpCode.CopyToReg, 
				OpCode.CopyToReg, 
				OpCode.CopyToReg, 
				OpCode.CopyToReg, 
				OpCode.CopyToReg, 
				OpCode.SaveToStack, 
				OpCode.SaveToStack,
				OpCode.Call, 
				OpCode.DeallocStack
			};
			var list = Lower(Constants.kRitualInvokationLargeArgCount);

			Assert.That(list.Count, Is.EqualTo(opList.Length));
			for (int idx = 0; idx < opList.Length; idx++)
				Assert.That(list[idx].opCode, Is.EqualTo(opList[idx]));
		}

		[Test]
		public void LargeArgsDeclare()
		{
			var opList = new OpCode[] {
				OpCode.Label,
				OpCode.EnterFunc, 
				OpCode.LoadFromStack,
				OpCode.LoadFromStack,
				OpCode.CopyFromReg,
				OpCode.CopyFromReg,
				OpCode.CopyFromReg,
				OpCode.CopyFromReg,
				OpCode.CopyFromReg,
				OpCode.CopyFromReg,
				OpCode.LeaveFunc, 
				OpCode.Return
			};
			var list = Lower(Constants.kRitualDeclarationLargeArgCount);

			Assert.That(list.Count, Is.EqualTo(opList.Length));
			for (int idx = 0; idx < opList.Length; idx++)
				Assert.That(list[idx].opCode, Is.EqualTo(opList[idx]));
		}
	}
}
