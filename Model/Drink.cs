namespace Model;

public class Drink
{
    public string Id { get; }
    public string Name { get; }
    public DrinkType Type { get; }
    public string ImageUrl { get; }

    public Drink(string id)
    {
        // TODO: fetch data from db using id

        Id = id;
        
        // TODO: fill in fields
        
        // TODO: fill in fields
    }
}