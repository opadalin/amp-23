namespace CreationalPatterns.AbstractFactory;

public class ShoppingCart
{
    private readonly IDiscountService _discountService;
    private readonly IShippingCostsService _shippingCostsService;
    private readonly decimal _orderCosts;

    public ShoppingCart(IShoppingCartPurchaseFactory shoppingCartPurchaseFactory)
    {
        _discountService = shoppingCartPurchaseFactory.CreateDiscountService();
        _shippingCostsService = shoppingCartPurchaseFactory.CreateShippingCostsService();
        _orderCosts = 200;
    }

    public decimal CalculateOrderCosts() => _orderCosts - _orderCosts / 100 * _discountService.DiscountPercentage +
                                            _shippingCostsService.ShippingCosts;
}