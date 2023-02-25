using CreationalPatterns.AbstractFactory;
using Xunit;

namespace CreationalPatterns.Tests;

public class AbstractFactoryTests
{
    [Fact(DisplayName = "Can get order costs for Belgium shopping cart")]
    public void Test1()
    {
        // given
        IShoppingCartPurchaseFactory belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
        var shoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPurchaseFactory);

        // when
        var orderCosts = shoppingCartForBelgium.CalculateOrderCosts();

        // then
        Assert.Equal(180,orderCosts);
    }
    
    [Fact(DisplayName = "Can get order costs for Sweden shopping cart")]
    public void Test2()
    {
        // given
        IShoppingCartPurchaseFactory swedenShoppingCartPurchaseFactory = new SwedenShoppingCartPurchaseFactory();
        var shoppingCartForSweden = new ShoppingCart(swedenShoppingCartPurchaseFactory);

        // when
        var orderCosts = shoppingCartForSweden.CalculateOrderCosts();

        // then
        Assert.Equal(205,orderCosts);
    }
}