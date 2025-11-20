using Generics.Models;
using Generics.Enums;

namespace Generics.Services;

public class BeverageInitializer
{
public static void InitializeBeverages(Repository<Beverage> repo)
    {
        repo.Add(new Beverage("Coca Cola", "USA", 0.0, Cheerio.Cheers));
        repo.Add(new Beverage("Fanta", "Germany", 0.0, Cheerio.Cheers));
        repo.Add(new Beverage("Sprite", "USA", 0.0, Cheerio.Cheers));
        repo.Add(new Beverage("Solo", "Norway", 0.0, Cheerio.Cheers));
        repo.Add(new Beverage("Pepsi Max", "USA", 0.0, Cheerio.Cheers));
    }

    public static void InitializeBeers(Repository<Beer> repo)
    {
        repo.Add(new Beer("Heineken", "Netherlands", 5.0, Cheerio.Skål, "Lager"));
        repo.Add(new Beer("Guinness", "Ireland", 4.2, Cheerio.Slainte, "Stout"));
        repo.Add(new Beer("Corona", "Mexico", 4.5, Cheerio.Cheers, "Pale Lager"));
        repo.Add(new Beer("Budweiser", "USA", 5.0, Cheerio.Cheers, "Lager"));
        repo.Add(new Beer("Amstel", "Netherlands", 5.0, Cheerio.Salut, "Lager"));
    }
}
