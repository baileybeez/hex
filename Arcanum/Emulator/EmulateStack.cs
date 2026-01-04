using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public const int kMaxStackSize = 65535;

		private readonly byte[] _stack = new byte[kMaxStackSize];
		private int _sp = kMaxStackSize - 1;

		public int StackPointer { get { return _sp; } }

		public void AllocateStackSpace(int reqSize)
		{
			if (_sp - reqSize < 0)
				throw new HexException("Emulator ran out of stack space!");

			_sp -= reqSize;
		}

		public void ReleaseStackSpace(int size)
		{
			if (_sp + size >= kMaxStackSize)
				throw new HexException("Emulator tried to free too much stack space!");

			_sp += size;
		}

		public void SetStackValue(int offset, UInt64 val)
		{
			byte[] valBytes = BitConverter.GetBytes(val);
			for (int i = 0; i < valBytes.Length; i++)
				_stack[_sp + offset + i] = valBytes[i];
		}

		public UInt64 GetStackValue(int offset)
		{
			byte[] valBytes = new byte[8];
			for (int i = 0; i < valBytes.Length; i++)
				valBytes[i] = _stack[_sp + offset + i];

			return BitConverter.ToUInt64(valBytes, 0);
		}
	}
}
