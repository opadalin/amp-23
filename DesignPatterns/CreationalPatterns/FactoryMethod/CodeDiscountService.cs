using System;

namespace CreationalPatterns.FactoryMethod;

/// <summary>
/// Concrete Product
/// </summary>
public class CodeDiscountService : DiscountService
{
    private readonly Guid _code;

    public CodeDiscountService(Guid code)
    {
        _code = code;
    }

    public override int DiscountPercentage => 15;
}