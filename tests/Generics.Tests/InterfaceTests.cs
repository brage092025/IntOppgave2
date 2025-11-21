using Generics.Interfaces;
using Generics.Models;
using Generics.Services;

namespace Generics.Tests;

public class InterfaceTests
{
 
 [Fact]
    public void Repository_Implements_IRepositoryInterface()
    {
        // Arrange & Act
        var repo = new Repository<Beverage>();

        // Assert
        Assert.IsAssignableFrom<IRepository<Beverage>>(repo);
    }

    [Fact]
    public void IRepository_InterfaceMethods_Exist()
    {
        // Arrange
        var repoType = typeof(IRepository<Beer>);

        // Act & Assert
        Assert.NotNull(repoType.GetMethod("Add"));
        Assert.NotNull(repoType.GetMethod("Remove"));
        Assert.NotNull(repoType.GetMethod("GetAll"));
        Assert.NotNull(repoType.GetMethod("Get"));
        Assert.NotNull(repoType.GetProperty("Count"));
    }

}
