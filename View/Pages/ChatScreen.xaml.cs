namespace View.Pages;
using Model;

public partial class ChatScreen : ContentPage
{
    public ChatScreen()
    {
        InitializeComponent();
    }

    private async void SendMessage(object sender, EventArgs e)
    {
        String messageToSend = chatbox.Text?.Trim();
        //Message Message = new Message(messageToSend,User.GetDummyUser(), DateTime.Now);
        ChatMessageView.Children.Add(new Label { Text = messageToSend});

    }
}