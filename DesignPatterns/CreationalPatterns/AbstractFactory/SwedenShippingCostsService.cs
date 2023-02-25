namespace CreationalPatterns.AbstractFactory;

/// <summary>
/// ConcreteProduct
/// </summary>
public class SwedenShippingCostsService : IShippingCostsService
{
    public decimal ShippingCosts => 25;
}