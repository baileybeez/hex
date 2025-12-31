using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
   public sealed class U64Literal : Expression
   {
      public uint Value { get; set; }

      public U64Literal(uint value)
         : base(ExpressionTypes.NumberLiteral)
      {
			Value = value;
      }
   }
}
