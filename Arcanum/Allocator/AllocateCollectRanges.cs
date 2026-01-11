
using Hex.Arcanum.Common;

namespace Hex.Arcanum.Allocator
{
	public sealed partial class RegisterAllocator
	{
		private readonly Dictionary<string, LiveRange> _rangeMap = new();
		
		public List<LiveRange> ComputeLiveRanges(List<IRInst> irList)
		{
			_rangeMap.Clear();
			for (int idx = 0; idx < irList.Count; idx++)
			{
				var inst = irList[idx];
				if (ShouldProcess(inst))
				{
					UpdateRangeMap(inst.result, idx);
				}
				else if (inst.opCode == OpCode.Jump)
				{
					int idxDest = irList.FindIndex(a => a.opCode == OpCode.Label && a.result == inst.leftOperand);
					if (idxDest != -1 && idxDest < idx)
						UpdateAllInJumpRange(idxDest, idx);
				}

				foreach (var operand in GetValidOperands(inst))
				{
					if (IsValidVariable(operand))
						UpdateRangeMap(operand, idx);
				}
			}

			return _rangeMap.Values.ToList();
		}

		public void UpdateAllInJumpRange(int idxStart, int idxEnd)
		{
			var subset = _rangeMap.Values.Where(lr => lr.StartIdx >= idxStart || (lr.EndIdx > idxStart && lr.EndIdx <= idxEnd));
			foreach (var liveRange in subset)
				liveRange.UpdateEndIndex(idxEnd);
		}

		public void UpdateRangeMap(string entry, int idx)
		{			
			if (!_rangeMap.ContainsKey(entry))
				_rangeMap.Add(entry, new LiveRange(entry, idx));

			_rangeMap[entry].UpdateEndIndex(idx);
		}

		public bool ShouldProcess(IRInst inst)
		{
			switch (inst.opCode)
			{
				default:
					return inst.result != String.Empty && !RegisterUtils.IsReg(inst.result);

				case OpCode.Label:
				case OpCode.Call:
				case OpCode.Exit:
				case OpCode.SetupCall:
				case OpCode.EnterFunc:
				case OpCode.LeaveFunc:
					return false;
			}
		}

		public bool IsValidVariable(string str)
		{
			if (str.StartsWith("t"))
				return true;
			else if (Lexer.Lexer.IsIdentifier(str))
				return true;

			return false;
		}

		public IEnumerable<string> GetValidOperands(IRInst inst)
		{
			if (inst.leftOperand != null)
				yield return inst.leftOperand;
			if (inst.rightOperand != null)
				yield return inst.rightOperand;
		}
	}
}