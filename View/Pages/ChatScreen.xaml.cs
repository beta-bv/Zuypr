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
        //scrollviewChat.MaximumHeightRequest= DeviceDisplay.MainDisplayInfo.Height - 50;
    }

    private async void SendMessage(object sender, EventArgs e)
    {
        String messageToSend = chatbox.Text?.Trim();
        //Message Message = new Message(messageToSend,User.GetDummyUser(), DateTime.Now);
        ChatMessageView.Children.Add(new Border {
            Stroke = Color.FromArgb("#FFFFFF"),
            Background = Color.FromArgb("#008000"),
            StrokeThickness = 4,
            Padding = new Thickness(4, 2),
            HorizontalOptions = LayoutOptions.Start,
            Content = new Label
            {
                Text = messageToSend,
                TextColor = Colors.White,
                FontSize = 14,
                FontAttributes = FontAttributes.Bold
            }
        }) ;
    }
}