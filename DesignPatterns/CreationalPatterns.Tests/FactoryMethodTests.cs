using System;
using CreationalPatterns.FactoryMethod;
using Xunit;

namespace CreationalPatterns.Tests;

public class FactoryMethodTests
{
    [Theory(DisplayName = "Can get code discount percentage")]
    [InlineData("acb1543a-c758-4dcf-88a9-fe8b61062afb", 5)]
    [InlineData("957df9af-52ce-4a63-831a-e6f1ad5038b5", 10)]
    [InlineData("f0f3fbdc-947e-4f16-82ee-2fd93d96e969", 0)]
    public void Test1(string code, int expectedDiscount)
    {
        // given
        var codeDiscountFactory = new CodeDiscountFactory(Guid.Parse(code));

        // when
        var discountService = codeDiscountFactory.CreateDiscountService();

        // then
        Assert.Equal(expectedDiscount, discountService.DiscountPercentage);
        Assert.IsType<CodeDiscountService>(discountService);
    }

    [Theory(DisplayName = "Can get country discount percentage")]
    [InlineData("SE", 5)]
    [InlineData("BE", 20)]
    [InlineData("unlisted country", 0)]
    public void Test2(string countryCode, int expectedDiscount)
    {
        // given
        var countryDiscountFactory = new CountryDiscountFactory(countryCode);

        // when
        var discountService = countryDiscountFactory.CreateDiscountService();

        // then
        Assert.Equal(expectedDiscount, discountService.DiscountPercentage);
        Assert.IsType<CountryDiscountService>(discountService);
    }
}