
namespace Hex.Arcanum.Expressions
{
   public sealed class ParenthesizedStatement : Expression
   {
      public Expression InnerExpression { get; private set; }

      public ParenthesizedStatement(Expression expr)
         : base(Common.ExpressionTypes.Parenthesized)
      {
         InnerExpression = expr;
      }
   }
}
