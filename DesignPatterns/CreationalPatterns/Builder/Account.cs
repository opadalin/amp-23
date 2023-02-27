using System;
using System.Linq;

namespace CreationalPatterns.Builder;

public class Account
{
    public AccountNumber AccountNumber { get; }
    public LegalPerson Owner { get; }
    public Percentage Interest { get; }
    public Money CreditLimit { get; private set; }
    public AccountNumber FallbackAccount { get; private set; }

    private Account(
        AccountNumber accountNumber,
        LegalPerson owner,
        Percentage interest)
    {
        ArgumentNullException.ThrowIfNull(accountNumber);
        ArgumentNullException.ThrowIfNull(owner);
        ArgumentNullException.ThrowIfNull(interest);

        AccountNumber = accountNumber;
        Owner = owner;
        Interest = interest;
    }

    private void CheckInvariants()
    {
        if ((FallbackAccount != null ^ CreditLimit != null) is false)
        {
            throw new InvalidOperationException(
                "Invalid account state! Account is not allowed to have both a credit limit and a fallback account.");
        }
    }

    public class Builder
    {
        private Account _product;

        public Builder(AccountNumber number, LegalPerson owner, Percentage interest)
        {
            _product = new Account(number, owner, interest);
        }

        public Builder WithCreditLimit(Money creditLimit)
        {
            ArgumentNullException.ThrowIfNull(_product);
            _product.CreditLimit = creditLimit;
            return this;
        }

        public Builder WithFallbackAccount(AccountNumber fallbackAccount)
        {
            ArgumentNullException.ThrowIfNull(_product);
            _product.FallbackAccount = fallbackAccount;
            return this;
        }

        public Account Build()
        {
            ArgumentNullException.ThrowIfNull(_product);
            _product.CheckInvariants();
            var result = _product;
            _product = null;
            return result;
        }
    }
}

public class Money
{
    public Money(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }
}

public class Percentage
{
    public Percentage(decimal value)
    {
        Value = value;
    }

    public decimal Value { get; }
}

public class LegalPerson
{
    public LegalPerson(string firstName, string lastName, string personId)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentNullException(firstName);
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentNullException(lastName);
        }

        if (string.IsNullOrWhiteSpace(personId))
        {
            throw new ArgumentNullException(personId);
        }

        FirstName = firstName;
        LastName = lastName;
        PersonId = personId;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string PersonId { get; }
    public string FullName => $"{FirstName} {LastName}";
}

public class AccountNumber
{
    private const int Length = 11;

    public AccountNumber(string value)
    {
        if (value.All(char.IsDigit) is false)
        {
            throw new FormatException(
                $"{value} is not a valid account number. Account number can only contain numeric characters");
        }

        if (value.Length != Length)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value,
                $"An account number must be exactly {Length} characters long");
        }

        Value = value;
    }

    public string Value { get; }
}