namespace Controller;
using Model;

    public class Chat
    {
    public User[] ChatMembers { get; set; } = new User[2];  //wss aanpassen voor het maken van een group chat + user 1 is de gebruiker voor dit prototype
    public List<Message> Messages { get; private set; } = new List<Message> { };
    
    public Chat(User[] chatMembers)
    {
            ChatMembers = chatMembers;
            Messages = DummyMessages(ChatMembers[0], ChatMembers[1]);
    }

    public bool AddMessageToList(Message message)
    {
        Messages.Add(message);                               //werk nog effe die if statement uit voor een mogelijke failure
        return true;
    }

    public List<Message> DummyMessages(User us1, User us2) {
        List<Message> dummyList = new List<Message>();
        dummyList.Add(new Message("hoi", us2, new DateTime(2004, 1, 1)));
        dummyList.Add(new Message("hoi", us1, new DateTime(2004, 1, 1)));
        dummyList.Add(new Message("gaat goed man", us2, new DateTime(2004, 1, 2)));
        return dummyList;
            
    }
}

