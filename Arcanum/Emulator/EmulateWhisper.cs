using Hex.Arcanum.Common;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void EmulateWhisper(IRInst inst)
		{
			if (_console == null || inst.leftOperand == null)
				return;

			string? text = null;
			if (!TryGetValue(inst.leftOperand, out object val))
				text = inst.leftOperand;
			else if (val != null)
				text = val.ToString();

			if (text != null)
				_console.Write(text);
		}
	}
}
