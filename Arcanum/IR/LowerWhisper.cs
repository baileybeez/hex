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

			Emit(OpCode.Whisper, String.Empty, whisper.Text);

			return String.Empty;
		}
	}
}
