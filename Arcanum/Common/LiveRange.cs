
namespace Hex.Arcanum.Common
{
	public sealed class LiveRange
	{
		public string VarName { get; private set; }
		public int StartIdx { get; private set; }
		public int EndIdx { get; private set; }
		public Registers? AssignedReg { get; set; } = null;
		public int? AssignedStackSlot { get; set; } = null;

		public LiveRange(string varName, int startIdx)
		{
			VarName = varName;
			StartIdx = startIdx;
			EndIdx = startIdx;
		}

		public void UpdateEndIndex(int idx)
		{
			EndIdx = Math.Max(this.EndIdx, idx);
		}
	}
}
