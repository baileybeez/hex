using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;
using Hex.Arcanum.Interfaces;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		private readonly List<IRInst> _instList = new();
		private Dictionary<string, int> _labelMap = new();
		private readonly Dictionary<string, object> _memory = new();
		private IConsole? _console = null;
		private int _ip = 0;

		public Emulator() 
		{
			SetupHandlerMap();
		}

		public void SetConsole(IConsole? console)
		{
			_console = console;
		}

		public int MemCount() => _memory.Count;

		public void Reset()
		{
			_memory.Clear();
		}

		public void Run(List<IRInst> irList, string? entryPoint = null)
		{
			_instList.Clear();
			if (entryPoint != null)
			{
				_instList.Add(new IRInst(OpCode.Call, string.Empty, $"func_{entryPoint}", null));
				_instList.Add(new IRInst(OpCode.Exit, string.Empty, null, null));
			}
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

			if (entryPoint == null && _memory.Count > 0)
				Console.WriteLine(GetValue(_memory.Keys.Last()));
		}

		public void DumpMemory()
		{
			foreach (string key in _memory.Keys)
				Console.WriteLine($"{key}\t: {_memory[key]}");
		}
	}
}
