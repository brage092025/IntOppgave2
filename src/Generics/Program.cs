using Generics.Interfaces;
using Generics.Models;
using Generics.Services;

namespace Generics;


internal class Program
{
    static void Main()
    {
        var beverageRepo = new Repository<Beverage>();
        var beerRepo = new Repository<Beer>();

        // Initialize sample beverages and beers
        BeverageInitializer.InitializeBeverages(beverageRepo);
        BeverageInitializer.InitializeBeers(beerRepo);

        RunMenu(beverageRepo, beerRepo);
    }

    static void RunMenu(IRepository<Beverage> beverageRepo, IRepository<Beer> beerRepo)
    {
        while (true)
        {
            Console.WriteLine("\n=== Drink Menu ===");
            Console.WriteLine("1. List beverages");
            Console.WriteLine("2. List beers");
            Console.WriteLine("3. Add beverage");
            Console.WriteLine("4. Remove beverage");
            Console.WriteLine("5. Drink a beverage");
            Console.WriteLine("6. Exit");

            Console.Write("Choose: ");
            string? input = Console.ReadLine();

            Action? command = input switch
                {
                    "1" => () => ListItems(beverageRepo.GetAll()),
                    "2" => () => ListItems(beerRepo.GetAll()),
                    "3" => () => AddBeverage(beverageRepo),
                    "4" => () => RemoveBeverage(beverageRepo),
                    "5" => () => DrinkBeverage(beverageRepo),
                    "6" => () => Environment.Exit(0),
                    _   => () => Console.WriteLine("Invalid choice.")
                };

            command.Invoke();

        }
    }

    static void ListItems<T>(IEnumerable<T> items)
    {
        Console.WriteLine();
        foreach (var item in items)
            Console.WriteLine(item);
    }

    static void AddBeverage(IRepository<Beverage> repo)
    {
        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Country: ");
        string country = Console.ReadLine() ?? "";

        Console.Write("ABV: ");
        if (!double.TryParse(Console.ReadLine(), out double abv))
            abv = 0;

        repo.Add(new Beverage(name, country, abv, Enums.Cheerio.Cheers));
        Console.WriteLine("Added!");
    }

    static void RemoveBeverage(IRepository<Beverage> repo)
    {
        Console.Write("Enter beverage name to remove: ");
        string name = Console.ReadLine() ?? "";

        var bev = repo.Get(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (bev != null)
        {
            repo.Remove(bev);
            Console.WriteLine("Removed.");
        }
        else
        {
            Console.WriteLine("Not found.");
        }
    }

    static void DrinkBeverage(IRepository<Beverage> repo)
    {
        Console.Write("Which beverage do you want to drink? ");
        string name = Console.ReadLine() ?? "";

        var bev = repo.Get(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (bev != null)
        {
            bev.Drink();
        }
        else
        {
            Console.WriteLine("Not found.");
        }
    }
}
