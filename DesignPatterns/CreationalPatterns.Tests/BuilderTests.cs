using System;
using CreationalPatterns.Builder;
using Xunit;

namespace CreationalPatterns.Tests;

public class BuilderTests
{
    [Fact(DisplayName = "Can build a car")]
    public void Test1()
    {
        // given
        var garage = new Garage();

        var miniBuilder = new MiniBuilder();
        var bmwBuilder = new BMWBuilder();

        // when
        garage.Construct(bmwBuilder);
        garage.Construct(miniBuilder);
        var actual = garage.Show();

        // then
        Assert.Equal("Car of type Mini has part 'not a V8. Car of type Mini has part '3-door with stripes. ", actual);
    }

    [Fact(DisplayName = "Can create an account with credit limit")]
    public void Test2()
    {
        // given
        var accountBuilder = new Account.Builder(
            new AccountNumber("08767652422"),
            new LegalPerson("Adam", "Lindström", "198004212398"),
            new Percentage(7));

        // when
        var account = accountBuilder
            .WithCreditLimit(new Money(100000))
            .Build();

        // then
        Assert.NotNull(account);
        Assert.NotNull(account.CreditLimit);
    }

    [Fact(DisplayName = "Can create an account with fallback account")]
    public void Test3()
    {
        // given
        var accountBuilder = new Account.Builder(
            new AccountNumber("08767652422"),
            new LegalPerson("Adam", "Lindström", "198004212398"),
            new Percentage(7));

        // when
        var account = accountBuilder
            .WithFallbackAccount(new AccountNumber("08767652423"))
            .Build();

        // then
        Assert.NotNull(account);
        Assert.NotNull(account.FallbackAccount);
    }


    [Fact(DisplayName = "Creating an account with both fallback account and credit limit should raise exception")]
    public void Test4()
    {
        // given
        var accountBuilder = new Account.Builder(
            new AccountNumber("08767652422"),
            new LegalPerson("Adam", "Lindström", "198004212398"),
            new Percentage(7));

        // when
        Assert.Throws<InvalidOperationException>(() => accountBuilder
            .WithFallbackAccount(new AccountNumber("08767652423"))
            .WithCreditLimit(new Money(100000))
            .Build());
    }
}