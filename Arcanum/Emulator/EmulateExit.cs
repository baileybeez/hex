using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void EmulateExit(IRInst inst)
		{
			_ip = _instList.Count;
		}
	}
}