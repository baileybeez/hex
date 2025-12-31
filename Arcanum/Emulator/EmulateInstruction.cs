using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void EmulateInstruction(IRInst inst)
		{
			if (!_handlerMap.TryGetValue(inst.opCode, out var handler))
				throw new HexException($"No handler provided for OpCode {inst.opCode}");
				
			handler(inst);
		}
	}
}