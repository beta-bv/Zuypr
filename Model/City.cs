namespace Model;

public class City
{
    public string Id { get; }
    public string Name { get; }
    
    // TODO: geolocation?

    public City(string id)
    {
        // TODO: fetch data from db using id

        Id = id;

        // TODO: fill in fields

        // TODO: fill db with known cities in the Netherlands
    }
}