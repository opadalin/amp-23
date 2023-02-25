namespace CreationalPatterns.AbstractFactory;

/// <summary>
/// ConcreteFactory
/// </summary>
public class SwedenShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
{
    public IDiscountService CreateDiscountService()
    {
        return new SwedenDiscountService();
    }

    public IShippingCostsService CreateShippingCostsService()
    {
        return new SwedenShippingCostsService();
    }
}