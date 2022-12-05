namespace View.Pages;

using Microsoft.Maui.Controls.Shapes;
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
        ChatMessageView.Children.Add(new Border {
            Stroke = Color.FromArgb("#FFFFFF"),
            Background = Color.FromArgb("#008000"),
            StrokeThickness = 4,
            Padding = new Thickness(16, 8),
            HorizontalOptions = LayoutOptions.Start,
            StrokeShape = new Rectangle,
            Content = new Label
            {
                Text = messageToSend,
                TextColor = Colors.White,
                FontSize = 18,
                FontAttributes = FontAttributes.Bold
            }
        }) ;
    }
}