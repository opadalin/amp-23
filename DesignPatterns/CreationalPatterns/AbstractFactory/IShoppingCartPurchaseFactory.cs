namespace CreationalPatterns.AbstractFactory;

/// <summary>
/// AbstractFactory
/// </summary>
public interface IShoppingCartPurchaseFactory
{
    IDiscountService CreateDiscountService();
    IShippingCostsService CreateShippingCostsService();
}