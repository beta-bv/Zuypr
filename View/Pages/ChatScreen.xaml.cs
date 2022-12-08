namespace View.Pages;

//using Android.App;                             !!!aanzetten wanneer nodig!!! is effe uitgecomment omdat hij voor een of andere reden hierover crashde 
using Microsoft.Maui.Controls.Shapes;
using Model;
using Controller;
using Message = Model.Message;

public partial class ChatScreen : ContentPage
{
    public Match MatchChatScreen { get; set; }

    public ChatScreen(Match match)
    {
        dummydb.Initialize();
        InitializeComponent();
        LabelUserName.FontSize = 20;
        MatchChatScreen = match;
        Chat chat = new Chat(match);
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

    /// <summary>
    /// Creates a message and shows it in the message stack
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SendMessage(object sender, EventArgs e)
    {
        String messageToSend = chatbox.Text?.Trim();
        Message Message = new Message(messageToSend, Controller.Auth.getUser(), DateTime.Now);
        MatchChatScreen.Messages.Add(Message);
        PlaceText(true, messageToSend);
        chatbox.Text = "";
        await scrollviewChat.ScrollToAsync(ChatMessageView, ScrollToPosition.End, false);
    }
    
    /// <summary>
    /// Enabled en disabled de send knop
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnTextChanged(object sender, EventArgs e)
    {
        String messageTyped = chatbox.Text.Trim();
        if (messageTyped != null && !messageTyped.Equals(""))
        {
            sendMessage.IsEnabled = true;
            sendMessage.BackgroundColor = Color.FromArgb("#FF006400");
        }
        else
        {
            sendMessage.IsEnabled = false;
            sendMessage.BackgroundColor = Color.FromArgb("#FFD3D3D3");
        }
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
}