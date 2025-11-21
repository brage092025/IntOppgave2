using Generics.Models;
using Generics.Services;
using Generics.Enums;

namespace Generics.Tests;

public class RepositoryTests
{


    // BASIC FUNCTIONALITY TESTS

    [Fact]
    public void Add_ShouldIncreaseCount()
    {
        // Arrange
        var repo = new Repository<Beverage>();

        // Act
        repo.Add(new Beverage("Beverage", "Country", 0.0, Cheerio.Cheers));

        // Assert
        Assert.Equal(1, repo.Count);
    }

    [Fact]
    public void Add_ShouldStoreItem()
    {
        // Arrange
        var repo = new Repository<string>();

        // Act
        repo.Add("hello");

        // Assert
        Assert.Contains("hello", repo.GetAll());
    }

    [Fact]
    public void Remove_ShouldReturnTrue_WhenItemExists()
    {
        // Arrange
        var repo = new Repository<int>();
        repo.Add(1);

        // Act
        var result = repo.Remove(1);

        // Assert
        Assert.True(result);
        Assert.Equal(0, repo.Count);
    }

    [Theory]
    [InlineData(1, 2)]
    [InlineData(100, 200)]
    public void Remove_ShouldReturnFalse_WhenItemDoesNotExist(int existing, int missing)
    {
        // Arrange
        var repo = new Repository<int>();
        repo.Add(existing);

        // Act
        var result = repo.Remove(missing);

        // Assert
        Assert.False(result);
        Assert.Equal(1, repo.Count);
    }

    [Fact]
    public void Get_ShouldReturn_MatchingItem()
    {
        // Arrange
        var repo = new Repository<string>();
        repo.Add("abc");
        repo.Add("xyz");

        // Act
        var result = repo.Get(s => s.StartsWith("x"));

        // Assert
        Assert.Equal("xyz", result);
    }

    [Fact]
    public void GetAll_ShouldReturn_AllItems()
    {
        // Arrange
        var repo = new Repository<int>();
        repo.Add(1);
        repo.Add(2);
        repo.Add(3);

        // Act
        var items = repo.GetAll().ToList();

        // Assert
        Assert.Equal(3, items.Count);
        Assert.Contains(1, items);
        Assert.Contains(2, items);
        Assert.Contains(3, items);
    }


    // EDGE CASE TESTS
    [Fact]
    public void Add_NullItem_ShouldThrowArgumentNullException() // This test fails since there is no constraint on T
    {
        // Arrange
        var repo = new Repository<string>();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => repo.Add(null!));
    }

    [Fact]
    public void Add_NullItem_ShouldBeStoredAsTAllowsNull() // This test is added to show that null can be added since there is no constraint on T
    {
        // Arrange
        var repo = new Repository<string>();

        // Act
        repo.Add(null!);

        // Assert
        Assert.Equal(1, repo.Count);
        Assert.Contains(null, repo.GetAll());
    }


    [Fact]
    public void Get_NullPredicate_ShouldThrowArgumentNullException()
    {
        // Arrange
        var repo = new Repository<int>();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => repo.Get(null!));
    }

    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(999)]
    public void Add_Duplicates_ShouldStoreAll(int value)
    {
        // Arrange
        var repo = new Repository<int>();

        // Act
        repo.Add(value);
        repo.Add(value);

        // Assert
        Assert.Equal(2, repo.Count);
    }

    [Fact]
    public void Remove_OnEmptyRepo_ShouldReturnFalse()
    {
        // Arrange
        var repo = new Repository<int>();

        // Act
        var result = repo.Remove(10);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Get_OnEmptyRepo_ShouldReturnNull()
    {
        // Arrange
        var repo = new Repository<string>();
        
        // Act
        var result = repo.Get(s => s.Length > 0);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void Get_ShouldReturnFirstMatch_WhenMultipleMatches()
    {
        // Arrange
        var repo = new Repository<int>();
        repo.Add(10);
        repo.Add(10);
        repo.Add(20);

        // Act
        var result = repo.Get(x => x == 10);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void GetAll_ShouldReturnCopy_NotAllowExternalMutation()
    {
        // Arrange
        var repo = new Repository<int>();
        repo.Add(1);

        // Act
        var externalList = repo.GetAll().ToList();
        externalList.Add(99);

        // Assert
        Assert.Single(repo.GetAll());  
        Assert.DoesNotContain(99, repo.GetAll());
    }

}
