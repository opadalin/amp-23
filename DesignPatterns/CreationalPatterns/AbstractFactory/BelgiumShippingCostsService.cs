namespace CreationalPatterns.AbstractFactory;

/// <summary>
/// ConcreteProduct
/// </summary>
public class BelgiumShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 20;
}