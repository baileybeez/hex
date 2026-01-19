using Hex.Arcanum.Common;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void EmulateWhisper(IRInst inst)
		{
			if (_console == null || inst.leftOperand == null)
				return;

			string str = "";
			UInt64 addr = LookupString(inst.leftOperand);
			if (addr != Emulator.kNullRef)
				str = ReadString(addr);
			else
				str = GetU64(inst.leftOperand).ToString();

			_console.Write(str);

			// string? text = null;
			// if (!TryGetValue(inst.leftOperand, out object val))
			// 	text = inst.leftOperand;
			// else if (val != null)
			// 	text = val.ToString();
			// 
			// if (text != null)
			// 	_console.Write(text);
		}
	}
}
