namespace Model;

public class Match : Group
{
    public Match(string id)
    {
        // TODO: fetch data from db using id

        Id = id;

        // TODO: call other constructor to fill in fields
    }

    public Match(User user1, User user2)
    {
        Type = GroupType.Match;
        Users = new List<User>
        {
            user1, user2
        };
    }
}