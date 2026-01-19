using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Allocator
{
	public sealed partial class RegisterAllocator
	{
		private Dictionary<string, LiveRange> _allocMap = new();

		public RegisterAllocator() { }
		
		public void Reset()
		{
			_rangeMap.Clear();
			_activeList.Clear();
			_usedCalleeList.Clear();
			_allocMap.Clear();
		}

		public List<IRInst> ProcessAllocations(List<IRInst> irList, RegAllocateResult resAllocs)
		{
			_allocMap = resAllocs.RangeList.ToDictionary(a => a.VarName);

			var updatedIr = new List<IRInst>();
			for (int i = 0; i < irList.Count; i++)
				updatedIr.Add(RewriteInstruction(irList[i], i));
			
			return updatedIr;
		}

		public IRInst RewriteInstruction(IRInst ir, int idx) 
		{
			string? result = LookupAssignment(ir.result, idx);
			if (result == null)
				throw new Exception("IR Result cannot be assigned a null value.");

			string? left = LookupAssignment(ir.leftOperand, idx);
			if (IsDereference(ir.leftOperand))
				left = $"[{left}]";
			string? right = LookupAssignment(ir.rightOperand, idx);
			if (IsDereference(ir.rightOperand))
				right = $"[{right}]";

			return new IRInst(ir.opCode, result, left, right);
		}

		public bool IsDereference(string? str)
		{
			if (str == null)
				return false;

			return str.StartsWith(kDeRefPrefix) && str.EndsWith(kDeRefSuffix);
		}

		// deref instructions appear as a variable wrapped with [ and ]
		// e.g. [t0]
		public string UnwrapDeref(string str)
		{
			return str.Substring(1, str.Length - 2);
		}

		public string UnwrapVar(string str)
		{
			if (IsDereference(str))
				return UnwrapDeref(str);

			return str;
		}

		public string? LookupAssignment(string? str, int idx)
		{
			if (str == null)
				return null;

			// if there isn't an allocation entry, this is either a constant or a label
			string key = UnwrapVar(str);
			if (!_allocMap.ContainsKey(key))
				return str;
			
			var range = _allocMap[key];
			if (idx < range.StartIdx || idx > range.EndIdx)
				throw new HexException($"Variable '{key}' was accessed outside of viable live range.");

			if (range.AssignedReg.HasValue)
				return range.AssignedReg.Value.ToString();

			if (range.AssignedStackSlot.HasValue)
			{
				int offset = (range.AssignedStackSlot.Value + 1) * 8;
				return $"[rbp-{offset}]";
			}

			throw new HexException($"Variable '{str}' has no legal allocations.");
		}
	}
}
