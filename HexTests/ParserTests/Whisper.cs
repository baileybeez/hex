using Hex.Arcanum.Common;
using Hex.Arcanum.Expressions;

namespace HexTests.ParserTests
{
	public class WhisperTests : ParserTestUtilities
	{
		[Test]
		public void WhisperParse()
		{
			var scope = Parse(Constants.kConsoleOutput);
			var child = scope.Children.FirstOrDefault() as Whisper;

			Assert.That(child, Is.Not.Null);
			Assert.That(child.Type, Is.EqualTo(ExpressionTypes.Whisper));
			Assert.That(child.Text, Is.EqualTo("hello world"));
		}
	}
}
