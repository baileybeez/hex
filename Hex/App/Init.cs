#if WINDOWS
using System.Runtime.InteropServices;
#endif

namespace Hex.App
{
	public sealed partial class App
	{
#if WINDOWS
		public const int kStdOutHandle = -11;
		public const int kTrueType = 4;
		public const int kNormalWeight = 400;

		[DllImport("kernel32.dll", SetLastError = true)]
		static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		static extern IntPtr SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool bMaximumWindow, ref CONSOLE_FONT_INFO_EX lpConsoleCurrentFontEx);

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		struct CONSOLE_FONT_INFO_EX
		{
			public uint cbSize;
			public uint nFont;
			public short dwFontSizeX;
			public short dwFontSizeY;
			public int FontFamily;
			public int FontWeight;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string FaceName;
		}
#endif

		public bool Init()
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
#if WINDOWS
			SetConsoleFont("Noto Sans Runic", 16);
#endif
			return true;
		}

#if WINDOWS
		static void SetConsoleFont(string fontName, short fontSize = 16)
		{
			IntPtr hnd = GetStdHandle(kStdOutHandle);
			if (hnd == IntPtr.Zero)
				return;

			CONSOLE_FONT_INFO_EX info = new CONSOLE_FONT_INFO_EX();
			info.cbSize = (uint)Marshal.SizeOf(info);
			info.nFont = 0;
			info.dwFontSizeX = 0;
			info.dwFontSizeY = fontSize;
			info.FontFamily = kTrueType;
			info.FontWeight = kNormalWeight;
			info.FaceName = fontName;

			SetCurrentConsoleFontEx(hnd, false, ref info);
		}
#endif
	}
}