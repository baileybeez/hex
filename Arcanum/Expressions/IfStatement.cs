using Hex.Arcanum.Common;

namespace Hex.Arcanum.Expressions
{
    public sealed class IfStatement : Expression
    {
      public Expression Condition { get; private set; }
      public Scope InnerScope { get; private set; }

      public IfStatement(Expression condition, Scope scope)
         : base(ExpressionTypes.IfStatement)
      {
         Condition = condition;
         InnerScope = scope;
      }
    }
}
