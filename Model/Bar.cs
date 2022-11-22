namespace Model;

public class Bar
{
    public string Id { get; }
    public string Name { get; }
    public List<Drink> Drinks { get; }
    public City City { get; }

    public Bar(string id)
    {
        // TODO: fetch data from db using id

        Id = id;
        
        // TODO: fill in fields
        
        // TODO: fill db with known cities in the Netherlands
    }
}