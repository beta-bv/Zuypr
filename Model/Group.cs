namespace Model;

public abstract class Group
{
    public string Id { get; set; }
    public List<User> Users { get; set; }
    public GroupType Type { get; set; }
}