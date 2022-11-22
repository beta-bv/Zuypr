namespace Model;

public class User
{
    public string Id { get; }
    public string Name { get; }
    public string Email { get; }
    public DateTime DateOfBirth { get; }
    public City Location { get; }
    public string ImageUrl { get; }
    public Dictionary<Drink, DrinkTaste> Drinks { get; }

    public User(string id)
    {
        // TODO: fetch data from db using id

        Id = id;

        // TODO: call other constructor to fill in fields
    }

    public User(string name, string email, DateTime dateOfBirth, City city, string imageUrl,
        Dictionary<Drink, DrinkTaste> drinks)
    {
        Name = name;
        Email = email;
        DateOfBirth = dateOfBirth;
        Location = city;
        ImageUrl = imageUrl;
        Drinks = drinks;
    }
}