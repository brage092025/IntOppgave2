using Generics.Enums;

namespace Generics.Models;

public class Beverage(string name, string country, double abv, Cheerio cheers)
{
    public string Name { get; set; } = name;
    public string Country { get; set; } = country;
    public double ABV { get; set; } = abv;
    public Cheerio Cheers { get; set; } = cheers;

    public void Drink()
    {
        Console.WriteLine($"{Name}: {Cheers}!");
    }

      public override string ToString()
    {
        return $"{Name} ({Country}) – ABV: {ABV}%";
    }
}