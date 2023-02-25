namespace CreationalPatterns.AbstractFactory;

/// <summary>
/// ConcreteProduct
/// </summary>
public class SwedenDiscountService : IDiscountService
{
    public int DiscountPercentage => 10;
}