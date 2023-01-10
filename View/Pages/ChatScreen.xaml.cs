namespace View.Pages;

//using Android.App;                            // !!!aanzetten wanneer nodig!!! is effe uitgecomment omdat hij voor een of andere reden hierover crashde 
using Microsoft.Maui.Controls.Shapes;
using Model;
using Controller;
using Message = Model.Message;
using Windows.ApplicationModel.Chat;
using Microsoft.IdentityModel.Tokens;

public partial class ChatScreen : ContentPage
{
    private Match _matchChatScreen;
    //private System.Timers.Timer _timer;
    private IDispatcherTimer _timer;

    public ChatScreen(Match match)
    {
        InitializeComponent();
        _matchChatScreen = match;
        _timer = Application.Current.Dispatcher.CreateTimer();
        _timer.Interval = TimeSpan.FromSeconds(0.5);
        _timer.Tick += _timerElapsed;
        _timer.Start();
        //_timer = new System.Timers.Timer(500);
        //_timer.Elapsed += _timerElapsed;
        //_timer.Start();
        LabelUserName.Text = match.Users[1].Name; //bij groeps chats gaat dit stuk!
        ChatPfp.Source = match.Users[1].ProfileImage;

        foreach (Message message in match.Messages)
        {
            PlaceText(message);
        }
    }
    private void _timerElapsed(object sender, EventArgs e)
    {
        RefreshChat();
    }

    /// <summary>
    /// Creates a message and shows it in the message stack
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="ArgumentNullException"></exception>
    private async void SendMessage(object sender, EventArgs e)
    {
        string messageToSend = chatbox.Text?.Trim();
        Message message = new(messageToSend, Auth.User, DateTime.Now, _matchChatScreen.Users[1]);

        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }
        DatabaseContext db = new DatabaseContext();
        _matchChatScreen.Messages.Add(message);
        db.SaveChanges();
        PlaceText(message);

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
        string messageTyped = chatbox.Text.Trim();
        if (!messageTyped.Equals(""))
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
    /// <param name="message"><see cref="Message">Message</see> to be placed on screen</param>
    private void PlaceText(Message message)
    {
        Border renderableMessage = new()
        {
            StrokeThickness = 1,
            Padding = new Thickness(4, 2),
            Content = new Label
            {
                Text = message.Text,
                TextColor = Colors.White,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold,
                Padding = 10
            }
        };

        if (message.Sender.Equals(Auth.User))
        {
            renderableMessage.BackgroundColor = Color.FromArgb("#008000");
            renderableMessage.HorizontalOptions = LayoutOptions.End;
        }
        else
        {
            renderableMessage.BackgroundColor = Color.FromArgb("#808080");
            renderableMessage.HorizontalOptions = LayoutOptions.Start;
        }

        ChatMessageView.Children.Add(renderableMessage);
    }
    private void RefreshChat()
    {
        ChatMessageView.Children.Clear();
        DatabaseContext db = new DatabaseContext();
        List<Message> messages = db.Matches.First(m => m.Users.Contains(_matchChatScreen.Users[0]) && m.Users.Contains(_matchChatScreen.Users[1])).Messages;

        if(!messages.IsNullOrEmpty())
        {
            foreach (Message message in messages)
            {
                PlaceText(message);
            }
        }
    }
}