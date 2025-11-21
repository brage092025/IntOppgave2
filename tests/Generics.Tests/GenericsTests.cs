using Generics.Services;
using Generics.Models;
using Generics.Enums;

namespace Generics.Tests;

public class GenericTypeTests
{
    [Fact]
    public void Repository_ShouldStoreObject()
    {
        // Arrange
        var repo = new Repository<Beverage>();
        var drink = new Beverage("Cola", "USA", 0.0, Cheerio.Cheers);

        // Act
        repo.Add(drink);

        // Assert
        Assert.Single(repo.GetAll());
        Assert.Equal("Cola", repo.GetAll().First().Name);
    }

    [Fact]
    public void Get_ShouldFindObjectByPredicate()
    {
        // Arrange
        var repo = new Repository<Beverage>();
        repo.Add(new Beverage("Cola", "USA", 0.0, Cheerio.Cheers));
        repo.Add(new Beverage("Fanta", "Germany", 0.0, Cheerio.Cheers));

        // Act
        var result = repo.Get(b => b.Country == "Germany");

        // Assert
        Assert.Equal("Fanta", result!.Name);
    }
}
