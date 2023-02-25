namespace CreationalPatterns.AbstractFactory;

/// <summary>
/// ConcreteProduct
/// </summary>
public class BelgiumDiscountService : IDiscountService
{
    public int DiscountPercentage => 20;
}