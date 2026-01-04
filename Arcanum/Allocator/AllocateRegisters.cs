
using Hex.Arcanum.Common;

namespace Hex.Arcanum.Allocator
{
	public sealed partial class RegisterAllocator
	{
		private static readonly Registers[] _availableRegs = new Registers[]
		{
			// saved by Caller (free to use)
			Registers.R11, Registers.R10, Registers.R9, Registers.R8,
			Registers.RCX, Registers.RDX, Registers.RSI, Registers.RDI,

			// saved by Callee
			Registers.RBX, Registers.R12, Registers.R13, Registers.R14, Registers.R15,
		};

		private static readonly Registers[] _calleeSavedRegs = new Registers[]
		{
			Registers.RBX, Registers.R12, Registers.R13, Registers.R14, Registers.R15,
		};

		private List<LiveRange> _activeList = new();
		private HashSet<Registers> _usedCalleeList = new();

		public RegAllocateResult AllocateRegisters(List<LiveRange> rangeList)
		{
			int nextStackSlot = 0;

			var sorted = rangeList.OrderBy(r => r.StartIdx);
			foreach (var range in sorted)
			{
				_activeList = _activeList.Where(r => r.EndIdx >= range.StartIdx).OrderBy(r => r.EndIdx).ToList();
				if (TryAllocRegister(range))
					_activeList.Add(range);
				else
					range.AssignedStackSlot = nextStackSlot++;
			}

			return new RegAllocateResult(
				rangeList, 
				_usedCalleeList.ToList(), 
				nextStackSlot);
		}

		public bool TryAllocRegister(LiveRange range)
		{
			var usedSet = _activeList.Where(r => r.AssignedReg.HasValue).Select(r => r.AssignedReg).ToHashSet();
			var freeReg = _availableRegs.FirstOrDefault(r => !usedSet.Contains(r));
			if (freeReg == default(Registers))
				return false;

			range.AssignedReg = freeReg;
			if (IsCalleeSaved(freeReg))
				_usedCalleeList.Add(freeReg);

			return true;
		}

		public bool IsCalleeSaved(Registers reg)
		{
			return _calleeSavedRegs.Contains(reg);
		}
	}
}