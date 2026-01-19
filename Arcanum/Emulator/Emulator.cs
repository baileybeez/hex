using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.Interfaces;

namespace Hex.Arcanum.Emulator
{
	public enum EmulatorMemMode
	{
		Raw = 1, 
		Mapped = 2,
	}

	public sealed partial class Emulator
	{
		private readonly List<IRInst> _instList = new();
		private Dictionary<string, int> _labelMap = new();
		private IConsole? _console = null;
		private int _ip = 0;
		private EmulatorMemMode _memMode;

		public Emulator(EmulatorMemMode mem) 
		{
			_memMode = mem;
			SetupHandlerMap();
		}

		public void SetConsole(IConsole? console)
		{
			_console = console;
		}

		public void Reset()
		{
			ClearMemory();
		}

		public void Run(List<IRInst> irList)
		{
			_instList.Clear();
			_instList.AddRange(irList);

			_labelMap.Clear();
			for (int i = 0; i < _instList.Count; i++)
			{
				if (_instList[i].opCode == OpCode.Label)
				{
					string? lbl = _instList[i].result;
					if (lbl != null)
						_labelMap[lbl] = i;
				}
			}

			_ip = 0;
			while (_ip < _instList.Count)
			{
				EmulateInstruction(_instList[_ip]);
				_ip++;
			}
		}
	}
}
