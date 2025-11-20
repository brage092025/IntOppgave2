using Generics.Enums;

namespace Generics.Models;

public class Beer(string name, string country, double abv, Cheerio cheers, string type)
: Beverage(name, country, abv, cheers)
{
    public string Type { get; set; } = type;

}
