namespace View.Pages;

using Microsoft.Maui.Controls.Shapes;
using Model;

public partial class ChatScreen : ContentPage
{
    public ChatScreen()
    {
        InitializeComponent();
        LabelUserName.FontSize = 20;
        LabelUserName.Text = "User";
    }

    /// <summary>
    /// Creates a message and shows it in the message stack
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void SendMessage(object sender, EventArgs e)
    {
        String messageToSend = chatbox.Text?.Trim();
        Message Message = new Message(messageToSend, User.GetDummyUser(), DateTime.Now);
        ChatMessageView.Children.Add(new Border
        {
            Background = Color.FromArgb("#008000"),
            StrokeThickness = 1,
            Padding = new Thickness(4, 2),
            HorizontalOptions = LayoutOptions.Start,
            Content = new Label
            {
                Text = messageToSend,
                TextColor = Colors.White,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold
            }
        });
    }
}