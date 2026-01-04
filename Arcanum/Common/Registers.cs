
namespace Hex.Arcanum.Common
{
	public enum Registers
	{
		RAX, RBX, RCX, RDX, 
		RSI, RDI, RSP, RBP, 
		R8, R9, R10, R11, R12, R13, R14, R15,
	}

	public static class RegisterUtils
	{
		public const int kMinStackSize = 16;

		private static readonly Dictionary<string, Registers> _regMap = new()
		{
			{ "RAX", Registers.RAX }, { "RBX", Registers.RBX }, { "RCX", Registers.RCX }, { "RDX", Registers.RDX },
			{ "RSI", Registers.RSI }, { "RDI", Registers.RDI }, { "RSP", Registers.RSP }, { "RBP", Registers.RBP },
			{ "R8", Registers.R8 },   { "R9", Registers.R9 },   { "R10", Registers.R10 }, { "R11", Registers.R11 },
			{ "R12", Registers.R12 }, { "R13", Registers.R13 }, { "R14", Registers.R14 }, { "R15", Registers.R15 }
		};

		private static readonly string[] _funcArgs =
		{
			"RDI", "RSI", "RDX", "RCX", "R8", "R9"
		};

		public static bool TryGet(string name, out Registers result)
		{
			return _regMap.TryGetValue(name, out result);
		}

		public static string GetByArg(int idx)
		{
			return _funcArgs[idx];
		}

		public static int GetOffset(int idx)
		{
			return (idx - 6) * 8 + kMinStackSize;
		}

		public static int GetStackSize(int argCount)
		{
			int stackEntries = argCount - 6;
			int stackSize = 0;
			if (argCount > 6)
				stackSize = stackEntries * 8;

			return stackSize + kMinStackSize;
		}
	}
}
