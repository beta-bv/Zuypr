namespace Model;

public class GroupChat : Group
{
    public GroupChat(string id)
    {
        // TODO: fetch data from db using id

        Id = id;

        // TODO: call other constructor to fill in fields
    }

    public GroupChat(List<string> ids)
    {
        Type = GroupType.GroupChat;
        Users = new List<User>();
        foreach (string id in ids)
        {
            Users.Add(new User(id));
        }
    }

    public GroupChat(List<User> users)
    {
        Type = GroupType.GroupChat;
        Users = users;
    }
}