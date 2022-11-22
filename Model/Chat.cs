using System.Linq;

namespace Model;

public class Chat
{
    public string Id { get; }
    public Group Group { get; }
    public List<Message> Messages { get; }
    
    public Chat(string id)
    {
        // TODO: fetch data from db using id

        Id = id;

        // TODO: call other constructor to fill in fields
    }

    public Chat(Group group)
    {
        Group = group;
        Messages = new List<Message>();
    }
}