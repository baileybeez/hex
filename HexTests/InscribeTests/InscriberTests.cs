using Hex.Arcanum.Common;
using Hex.Arcanum.Inscriber;
using System.Text;

namespace HexTests.InscribeTests
{
	public class InscriberTests
	{
		[Test]
		public void Conjure()
		{
			Rune[] kTruth = { new Rune(RuneCodes.Conjure), new Rune(' '), 
								   new Rune(RuneCodes.Fire), new Rune(' '), 
									new Rune(RuneCodes.Salt),new Rune(' '),
									new Rune(RuneCodes.Ansuz), new Rune(' '), 
									new Rune(RuneCodes.ArrowLeft), new Rune(' '), 
									new Rune('1') };
			
			string output = (new Inscriber()).Run("conjure fire salt A as 1");
			var runeList = output.EnumerateRunes();
			int len = runeList.Count();

			Assert.That(kTruth.Length, Is.EqualTo(len));
			for (int i = 0; i < len; i++)
			{
				Assert.That(runeList.ElementAt(i), Is.EqualTo(kTruth[i]));
			}
		}
	}
}
