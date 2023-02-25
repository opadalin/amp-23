using System;
using System.Collections.Generic;

namespace CreationalPatterns.FactoryMethod;

/// <summary>
/// Concrete Product
/// </summary>
public class CodeDiscountService : DiscountService
{
    private readonly Guid _code;
    
    private readonly IReadOnlyDictionary<Guid, int> _codesApplicableForDiscount;

    public CodeDiscountService(Guid code)
    {
        _code = code;

        _codesApplicableForDiscount = new Dictionary<Guid, int>
        {
            {Guid.Parse("acb1543a-c758-4dcf-88a9-fe8b61062afb"), 5},
            {Guid.Parse("957df9af-52ce-4a63-831a-e6f1ad5038b5"), 10}
        };
    }

    public override int DiscountPercentage => _codesApplicableForDiscount.TryGetValue(_code, out var discount)
        ? discount
        : 0;
}