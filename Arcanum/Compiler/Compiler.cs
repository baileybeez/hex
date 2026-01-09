
using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Compiler
{
	public enum Platform
	{
		Linux
	}

	public sealed partial class Compiler
	{
		private readonly Platform _platform;
		private readonly List<string> _asm = new();

		public Compiler(Platform platform)
		{
			_platform = platform;
			SetupHandlerMap();
		}

		public List<string> Run(List<IRInst> irList)
		{
			_asm.Clear();
			for (int idx = 0; idx < irList.Count; idx++)
				CompileInstruction(irList[idx]);
			
			return _asm;
		}

		public void Emit(string asmLine)
		{
			_asm.Add(asmLine);
		}
	}
}
