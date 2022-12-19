namespace Controller;
using Model;
using System.Runtime.InteropServices;

public class Chat
{
    public User[] ChatMembers { get; set; } = new User[2];  //wss aanpassen voor het maken van een group chat + user 1 is de gebruiker voor dit prototype
    public List<Message> Messages { get; private set; } = new List<Message> { };

    public Chat(Match match) //HAALT NU ALLEEN DE EERSTE MATCH OP ZODRA @STAN KLAAR IS MET HET SELECTEER MATCHES DING VERDER UITWERKEN
    {
        Messages = match.Messages;
        ChatMembers[0] = match.Users[0];
        ChatMembers[1] = match.Users[1];
    }

    public bool AddMessageToList(Message message)
    {
        Messages.Add(message);                               //werk nog effe die if statement uit voor een mogelijke failure
        return true;
    }
    public bool getMessagesFromDB()
    {
        throw new NotImplementedException();
    }
}

