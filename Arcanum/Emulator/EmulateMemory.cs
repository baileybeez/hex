using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Hex.Arcanum.Emulator
{
	public sealed partial class Emulator
	{
		public const UInt64 kMemSize = 1024 * 1024;
		public const UInt64 kBaseAddr = 1024;
		public const UInt64 kNullRef = 0;

		// EmulatorMemMode.Raw
		private readonly byte[] _memory = new byte[kMemSize];
		private UInt64 _heapPointer = kBaseAddr;

		private readonly Dictionary<string, UInt64> _stringTable = new();

		// EmulatorMemMode.Mapped
		private readonly Dictionary<string, UInt64> _memMap = new();

		public void AssertMemoryMode(EmulatorMemMode mode)
		{
			if (mode != _memMode)
				throw new HexException($"Memory mode is currently set to {_memMode}. Cannot use {mode}");
		}

		public int MemCount()
		{
			AssertMemoryMode(EmulatorMemMode.Mapped);
			return _memMap.Count;
		}

		public byte GetByte(string key)
		{
			if (RegisterUtils.IsReg(key))
				return (byte)(GetRegister(key) & 0xFF);

			switch (_memMode)
			{
				default:
					throw new HexException($"Unsupported memory mode: {_memMode}");

				case EmulatorMemMode.Mapped:
					if (_memMap.ContainsKey(key))
						return (byte)(_memMap[key] & 0xFF);

					return 0;

				case EmulatorMemMode.Raw:
					if (key.StartsWith("["))
					{
						UInt64 addr = GetU64(key.Substring(1, key.Length - 2));
						return ReadByte(addr);
					}
					throw new NotImplementedException();
			}
		}

		public UInt64 GetU64(string key)
		{
			if (RegisterUtils.IsReg(key))
				return GetRegister(key);

			switch (_memMode)
			{
				default:
					throw new HexException($"Unsupported memory mode: {_memMode}");

				case EmulatorMemMode.Mapped:
					if (_memMap.ContainsKey(key))
						return _memMap[key];

					return 0;

				case EmulatorMemMode.Raw:
					if (key.StartsWith("["))
					{
						UInt64 addr = GetU64(key.Substring(1, key.Length - 2));
						return ReadByte(addr);
					}
					throw new NotImplementedException();
			}
		}

		public bool GetBool(string key)
		{
			UInt64 n = GetU64(key);
			return n != 0;
		}

		public char GetChar(string key)
		{
			UInt64 n = GetU64(key);
			return (char)n;
		}

		public void SetValue(string key, bool val)
		{
			UInt64 n = (UInt64)(val ? 1 : 0);

			SetValue(key, n);
		}

		public void SetValue(string key, UInt64 val)
		{
			if (RegisterUtils.IsReg(key))
				SetRegister(key, Convert.ToUInt64(val));
			else if (_memMode == EmulatorMemMode.Mapped)
				_memMap[key] = val;
			else
				throw new NotImplementedException();
		}

		public UInt64 GetUsedMemoryCount()
		{
			return _heapPointer; 
		}

		public void ClearMemory()
		{
			_heapPointer = kBaseAddr;
			_stringTable.Clear();
		}

		public void AssertAddress(ulong addr)
		{
			if (addr >= (ulong)kMemSize)
				throw new HexException($"Memory access out of bounds: 0x{addr:X}");
		}

		public byte ReadByte(UInt64 addr)
		{
			AssertAddress(addr);
			return _memory[addr]; 
		}

		public void WriteByte(UInt64 addr, byte val)
		{
			AssertAddress(addr);
			_memory[addr] = val; 
		}

		public UInt64 ReadU64(UInt64 addr)
		{
			UInt64 val = 0;
			for (int i = 0; i < 8; i++)
			{
				byte cb = ReadByte(addr + (UInt64)i);
				val |= (byte)(cb << (i * 8));
			}

			return val;
		}

		public void WriteU64(UInt64 addr, UInt64 val)
		{
			for (int i = 0; i < 8; i++)
			{
				byte cb = (byte)((val >> (i * 8)) & 0xFF);
				WriteByte(addr + (UInt64)i, cb);
			}
		}

		public UInt64 AllocateString(string str)
		{
			UInt64 addr = _heapPointer;
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			foreach (byte cb in bytes)
			{
				WriteByte(_heapPointer++, cb);
			}
			WriteByte(_heapPointer++, 0x00);

			return addr;
		}

		public UInt64 LookupString(string key)
		{
			if (!_stringTable.ContainsKey(key))
				return kNullRef;

			return _stringTable[key];
		}

		public string ReadString(UInt64 addr)
		{
			StringBuilder sb = new();
			char cb;
			do
			{
				cb = (char)ReadByte(addr++);
				if (cb != 0x00)
					sb.Append(cb);
			} while (cb != 0);
			return sb.ToString();
		}
	}
}
