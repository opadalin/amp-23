namespace CreationalPatterns.FactoryMethod;

/// <summary>
/// Concrete Product
/// </summary>
public class CountryDiscountService : DiscountService
{
    private readonly string _countryIdentifier;

    public CountryDiscountService(string countryIdentifier)
    {
        _countryIdentifier = countryIdentifier;
    }

    public override int DiscountPercentage
    {
        get
        {
            return _countryIdentifier switch
            {
                "SE" => 5,
                "BE" => 20,
                _ => 0
            };
        }
    }
}