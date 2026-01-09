
using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Compiler
{
	public sealed partial class Compiler
	{
		public void HandlePlatformExit(IRInst inst)
		{
			switch (_platform)
			{
				default:
					throw new HexException($"{_platform} not fully supported. Missing Exit operations.");

				case Platform.Linux:
					Emit("	MOV RDI, 0");
					Emit("	MOV RAX, 0x3C");
					Emit("	SYSCALL");
					break;
			}
		}

		public void HandleWhisper(IRInst inst)
		{
			switch (_platform)
			{
				default:
					throw new HexException($"{_platform} not fully supported. Missing Whisper operations.");

				case Platform.Linux:
					// TODO: perform syscall (requires writing strings out to resources)
					break;
			}
		}
	}
}