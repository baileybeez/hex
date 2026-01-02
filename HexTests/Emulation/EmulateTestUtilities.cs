using Hex.Arcanum.Common;
using Hex.Arcanum.Emulator;
using Hex.Arcanum.Interfaces;
using Hex.Arcanum.IR;
using Hex.Arcanum.Lexer;
using Hex.Arcanum.Parser;

namespace HexTests.Emulation
{
	public class EmulateTestUtilities
	{
		protected Emulator _emu = new Emulator();

		public void Emulate(string src, IConsole? console = null)
		{
			var lexer = new Lexer();
			var parse = new Parser();
			var lower = new IRLowerer();

			var lexList = lexer.Run(src);
			var scope = parse.Run(lexList);
			var irList = lower.Run(scope);

			_emu.SetConsole(console);
			_emu.Reset();
			_emu.Run(irList);
			if (console != null)
				console.Flush();
		}

		public UInt64 U64Val(string name)
		{
			return _emu.GetU64(_emu.GetValue(name));
		}
	}
}
