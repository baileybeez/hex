using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public const int kRegParamCount = 6;
		private static readonly Registers[] _intRegArgs = { 
			Registers.RDI, Registers.RSI, Registers.RDX, Registers.RCX, Registers.R8, Registers.R9 
		};

		private static readonly string[] _floatRegArgs = { 
			"XMM0", "XMM1", "XMM2", "XMM3", "XMM4", "XMM5", "XMM6", "XMM6"
		};
	}
}
