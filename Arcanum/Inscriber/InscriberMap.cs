using Hex.Arcanum.Common;
using System.Text;

namespace Hex.Arcanum.Inscriber
{
	public sealed partial class Inscriber
	{
		private Dictionary<string, string> _insMap = new();
		private Dictionary<char, string> _runeMap = new();

		public void SetupInscribeMap()
		{
			_insMap.Clear();
			_insMap["conjure"] = StringFrom(RuneCodes.Conjure);
			_insMap["salt"] = StringFrom(RuneCodes.Salt);
			_insMap["fire"] = StringFrom(RuneCodes.Fire);
			_insMap["earth"] = StringFrom(RuneCodes.Earth);
			_insMap["as"] = StringFrom(RuneCodes.ArrowLeft);
			_insMap["greq"] = StringFrom(RuneCodes.GreaterThanEquals);
			_insMap["lseq"] = StringFrom(RuneCodes.LessThanEquals);
			_insMap["neq"] = StringFrom(RuneCodes.NotExists);
			_insMap["eq"] = StringFrom(RuneCodes.Exists);
			_insMap["if"] = StringFrom([RuneCodes.SquareRightTick, RuneCodes.WaveArrowRight]);
			_insMap["{"] = "";
			_insMap["}"] = StringFrom(RuneCodes.SquareLeftTick);
		}

		public void SetupRuneMap()
		{
			_runeMap.Clear();
			_runeMap['A'] = StringFrom(RuneCodes.Ansuz);
			_runeMap['B'] = StringFrom(RuneCodes.Berkanan);
			_runeMap['C'] = StringFrom(RuneCodes.Thurisaz);
			_runeMap['D'] = StringFrom(RuneCodes.Dagaz);
			_runeMap['E'] = StringFrom(RuneCodes.Ehwaz);
			_runeMap['F'] = StringFrom(RuneCodes.Fehu);
			_runeMap['G'] = StringFrom(RuneCodes.Gebo);
			_runeMap['H'] = StringFrom(RuneCodes.Hagalaz);
			_runeMap['I'] = StringFrom(RuneCodes.Eiwaz);
			_runeMap['J'] = StringFrom(RuneCodes.Jera);
			_runeMap['K'] = StringFrom(RuneCodes.Kenaz);
			_runeMap['L'] = StringFrom(RuneCodes.Laguz);
			_runeMap['M'] = StringFrom(RuneCodes.Mannaz);
			_runeMap['N'] = StringFrom(RuneCodes.Naudiz);
			_runeMap['O'] = StringFrom(RuneCodes.Othila);
			_runeMap['P'] = StringFrom(RuneCodes.Perth);
			_runeMap['Q'] = StringFrom(RuneCodes.Phi);
			_runeMap['R'] = StringFrom(RuneCodes.Radio);
			_runeMap['S'] = StringFrom(RuneCodes.Sowilo);
			_runeMap['T'] = StringFrom(RuneCodes.Tiwaz);
			_runeMap['U'] = StringFrom(RuneCodes.Uruz);
			_runeMap['V'] = StringFrom(RuneCodes.Wunjo);
			_runeMap['W'] = StringFrom(RuneCodes.Ingwaz);
			_runeMap['X'] = StringFrom(RuneCodes.Oe);
			_runeMap['Y'] = StringFrom(RuneCodes.Aesc);
			_runeMap['Z'] = StringFrom(RuneCodes.Algiz);
		}

		public string StringFrom(int runeCode)
		{
			return (new Rune(runeCode)).ToString();
		}

		public string StringFrom(int[] runeList)
		{
			return String.Join("", runeList.Select(r => (new Rune(r))));
		}
	}
}
