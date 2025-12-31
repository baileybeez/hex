using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public void CopyU64(IRInst inst)
		{
			if (inst.leftOperand == null)
				return;

			object obj = GetValue(inst.leftOperand);
			if (obj == null)
				return;

			SetValue(inst.result, GetU64(obj));
		}
	}
}