
using Hex.Arcanum.Inscriber;

namespace Hex.App
{
	public sealed partial class App
	{
		public void Convert()
		{
			if (String.IsNullOrEmpty(_input) || !File.Exists(_input))
			{
				Console.WriteLine("Please provide a valid input file");
				return;
			}

			if (String.IsNullOrEmpty(_output))
				_output = Path.GetFileNameWithoutExtension(_input) + ".codex";

			try
			{
				string src = File.ReadAllText(_input);
				Inscriber ins = new Inscriber();
				string res = ins.Run(src);
				File.WriteAllText(_output, res);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}