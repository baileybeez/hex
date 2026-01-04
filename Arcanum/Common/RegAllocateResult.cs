
namespace Hex.Arcanum.Common
{
	public sealed class RegAllocateResult
	{
		private readonly List<LiveRange> _rangeList = new();
		private readonly List<Registers> _usedCalleeList = new();
		private readonly int _stackUsed = 0;

		public IReadOnlyList<LiveRange> RangeList { get {  return _rangeList; } }
		public IReadOnlyList<Registers> UsedCalleeList { get { return _usedCalleeList; } }
		public int UsedStackSize { get { return _stackUsed; } }

		public RegAllocateResult(List<LiveRange> rangeList, List<Registers> usedCalleeList, int usedStack) 
		{
			_rangeList.AddRange(rangeList);
			_usedCalleeList.AddRange(usedCalleeList);
			_stackUsed = usedStack;
		}
	}
}
