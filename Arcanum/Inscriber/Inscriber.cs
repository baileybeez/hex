
namespace Hex.Arcanum.Inscriber
{
	public sealed partial class Inscriber
	{
		public Inscriber() 
		{
			SetupInscribeMap();
			SetupRuneMap();
		}

		public string Run(string src)
		{
			string[] lineList = src.Split('\n');
			for (int i = 0; i < lineList.Length; i++)
			{
				lineList[i] = InscribeLine(lineList[i]);
			}

			return String.Join("\n", lineList);
		}

		public string InscribeLine(string line)
		{
			foreach (string key in _insMap.Keys)
				line = line.Replace(key, _insMap[key]);

			foreach (char cb in _runeMap.Keys)
				line = line.Replace(cb.ToString(), _runeMap[cb]);

			return line;
		}
	}
}
