namespace View.Pages;

//using Android.App;                             !!!aanzetten wanneer nodig!!! is effe uitgecomment omdat hij voor een of andere reden hierover crashde 
using Microsoft.Maui.Controls.Shapes;
using Model;
using Controller;

public partial class ChatScreen : ContentPage
{
    public ChatScreen()
    {
        dummydb.Initialize();
        InitializeComponent();
        LabelUserName.FontSize = 20;
        User user = dummydb.Users[0];
        Chat chat = new Chat(user.Matches);
        LabelUserName.Text = chat.ChatMembers[1].Name;   //bij groeps chats gaat dit stuk!
        for(int i = 0; i < chat.Messages.Count; i++)
        {
            if (chat.Messages[i].Sender.Equals(chat.ChatMembers[1])){
                PlaceText(false, chat.Messages[i].Text);
            }
            else
            {
                PlaceText(true, chat.Messages[i].Text);
            }
        }
    }
    private int _scrollviewY = 100;

    /// <summary>
    /// Creates a message and shows it in the message stack
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SendMessage(object sender, EventArgs e)
    {
        String messageToSend = chatbox.Text?.Trim();
        Message Message = new Message(messageToSend, User.GetDummyUser(), DateTime.Now);
        PlaceText(true, messageToSend);
        await scrollviewChat.ScrollToAsync(ChatMessageView, ScrollToPosition.End, false);
    }

    /// <summary>
    /// Plaats de text op het chat scherm
    /// </summary>
    /// <param name="userIsSender"></param>
    /// <param name="message"></param>
    private void PlaceText(bool userIsSender, String message)  
    {
        if (userIsSender)             //deze if statement kan wss veel korter, kon er alleen niet achter komen hoe dus voor nu effe dit. Het gaat om de horizontal options
        {
            _scrollviewY = _scrollviewY + 100;
            ChatMessageView.Children.Add(new Border
            {
                Background = Color.FromArgb("#008000"),
                StrokeThickness = 1,
                Padding = new Thickness(4, 2),
                HorizontalOptions = LayoutOptions.End,
                Content = new Label
                {
                    Text = message,
                    TextColor = Colors.White,
                    FontSize = 14,
                    FontAttributes = FontAttributes.Bold
                }
            });
            
        }
        else
        {
            _scrollviewY = _scrollviewY + 100;
            ChatMessageView.Children.Add(new Border
            {
                Background = Color.FromArgb("#808080"),
                StrokeThickness = 1,
                Padding = new Thickness(4, 2),
                HorizontalOptions = LayoutOptions.Start,
                Content = new Label
                {
                    Text = message,
                    TextColor = Colors.White,
                    FontSize = 14,
                    FontAttributes = FontAttributes.Bold
                }
            });
        }
    }

    private async void Simuleer(object sender, EventArgs e)
    {

        User userB = new User("userB", "userB@gmail.com", "GROTEDIKKE1!", new DateTime(2000, 1, 1));
        chatbox.Text = "WOW GROTE DIKKE DINGEN";
        SendMessage(sender, e);
    }
}