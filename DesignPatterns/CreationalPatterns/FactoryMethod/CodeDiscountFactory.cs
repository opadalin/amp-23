using System;

namespace CreationalPatterns.FactoryMethod;

/// <summary>
/// Concrete Creator
/// </summary>
public class CodeDiscountFactory : DiscountFactory
{
    private readonly Guid _code;

    public CodeDiscountFactory(Guid code)
    {
        _code = code;
    }
    
    public override DiscountService CreateDiscountService()
    {
        return new CodeDiscountService(_code);
    }
}