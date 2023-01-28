using System;
using System.Collections.Generic;
using System.Linq;
using CreationalPatterns.FactoryMethod;

namespace ConsoleApp;

public static class FactoryMethodProgram
{
    public static void Run()
    {
        var factories = new List<DiscountFactory>
        {
            new CodeDiscountFactory(Guid.NewGuid()),
            new CountryDiscountFactory("SE")
        };

        foreach (var discountService in factories.Select(factory => factory.CreateDiscountService()))
        {
            Console.WriteLine($"Percentage {discountService.DiscountPercentage} " +
                              $"coming from {discountService}");
        }
    }
}