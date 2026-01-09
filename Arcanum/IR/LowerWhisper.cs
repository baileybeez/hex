using Hex.Arcanum.Common;
using Hex.Arcanum.Exceptions;
using Hex.Arcanum.Expressions;

namespace Hex.Arcanum.IR
{
	public sealed partial class IRLowerer
	{
		public string LowerWhisper(Expression expr)
		{
			var whisper = AssertValid<Whisper>(expr);
			var textVal = LowerExpression(whisper.TextExpression);

			Emit(OpCode.Whisper, String.Empty, textVal);

			return String.Empty;
		}
	}
}
