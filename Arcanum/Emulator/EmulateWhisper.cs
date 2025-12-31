using Hex.Arcanum.Common;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void EmulateWhisper(IRInst inst)
		{
			if (_console == null || inst.leftOperand == null)
				return;

			if (TryGetValue(inst.leftOperand, out object val))
				_console.Write(val.ToString());
			else
				_console.Write(inst.leftOperand);
		}
	}
}
