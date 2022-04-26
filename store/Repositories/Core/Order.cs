namespace store.Repositories.Core;

public class Order<T>
{
  public System.Linq.Expressions.Expression<Func<T, object>> Expression { get; private set; }

  public bool Descending { get; private set; }

  public Order(System.Linq.Expressions.Expression<Func<T, object>> expression, bool descending = false)
  {
    this.Expression = expression;
    this.Descending = descending;
  }
}