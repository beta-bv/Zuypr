namespace Model;

public class Message
{
    public string Id { get; }
    public User Sender { get; }
    public DateTime SendTime { get; }
    public string Text { get; }

    public Message(string id)
    {
        // TODO: fetch data from db using id

        Id = id;

        // TODO: call other constructor to fill in fields
    }

    public Message(User sender, DateTime sendTime, string text)
    {
        Sender = sender;
        SendTime = sendTime;
        Text = text;
    }
}