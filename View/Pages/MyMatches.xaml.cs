using Microsoft.Maui.Layouts;
using Microsoft.VisualBasic;
using Model;
using Controller;
using System.Drawing.Printing;
using static System.Net.Mime.MediaTypeNames;
using Application = Microsoft.Maui.Controls.Application;

namespace View.Pages;

public partial class MyMatches : ContentPage
{
    public List<Match> AllMatches { get; set; }
    public List<User> Users { get; set; }
    public User CurrentUser { get; set; }
    public MyMatches()
    {
        AllMatches = Controller.Auth.User.Matches;
        Users = new List<User>();
        Queue<User> users = new Queue<User>();
        foreach (Match match in AllMatches)
        {
            if (Controller.Auth.User != match.UserA)
            {
                Users.Add(match.UserA);
                users.Enqueue(match.UserA);
            }
            else if (Controller.Auth.User != match.UserB)
            {
                Users.Add(match.UserB);
                users.Enqueue(match.UserB);
            }
        }
        InitializeComponent();
        if (Users.Count < 1)
        {
            NoMatchesPopUp();
        }
        BindingContext = this;
    }

    private void ProfileImage_OnClicked(object sender, EventArgs e)
    {
        ImageButton temp = (ImageButton)sender;
        Application.Current?.MainPage?.Navigation.PushAsync(new Profile((User)temp.BindingContext));
    }

    private void ChatButton_Clicked(object sender, EventArgs e)
    {
        ImageButton temp = (ImageButton)sender;
        Match match = FindMatchFromUser((User)temp.BindingContext);
        if (match != null) { Application.Current?.MainPage?.Navigation.PushAsync(new ChatScreen(match)); }
    }

    private Match FindMatchFromUser(User user)
    {
        foreach (Match match in AllMatches)
        {
            if (user == match.UserA || user == match.UserB)
            {
                return match;
            }
        }
        return null;
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        ImageButton temp = (ImageButton)sender;
        CurrentUser = (User)temp.BindingContext;
        MatchedPopUp();
    }

    public void NoMatchesPopUp()
    {
        Label labelNoMatches = new Label
        {
            Text = "No matches found",
            FontSize = 50,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };
        Content = labelNoMatches;
    }
    public void MatchedPopUp()
    {
        StackLayout stackLayout = new StackLayout
        {
            BackgroundColor = Colors.Black,
            VerticalOptions = LayoutOptions.Center
        };

        StackLayout stackLayoutTwo = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center
        };

        VerticalStackLayout verticalStackLayout = new VerticalStackLayout { };

        Microsoft.Maui.Controls.Image image = new Microsoft.Maui.Controls.Image
        {
            Source = CurrentUser.ProfileImage,
            HeightRequest = 300,
            WidthRequest = 300
        };

        Label labelName = new Label
        {
            Text = "Are you sure you want to delete " + CurrentUser.Name + "?",
            Margin = new Thickness(10, 10, 10, 10),
            HeightRequest = 25,
            HorizontalOptions = LayoutOptions.Center
        };

        HorizontalStackLayout horizontalStackLayout = new HorizontalStackLayout { HorizontalOptions = LayoutOptions.Center };

        Button buttonNo = new Button
        {
            HeightRequest = 40,
            WidthRequest = 100,
            Text = "No",
            Margin = new Thickness(0, 0, 50, 0)
        };

        Button buttonYes = new Button
        {
            HeightRequest = 40,
            WidthRequest = 100,
            Text = "Yes"
        };

        buttonNo.Clicked += (sender, e) =>
        {
            InitializeComponent();
        };
        buttonYes.Clicked += (sender, e) =>
        {
            Users.Remove(CurrentUser);
            //Auth.removeMatch(CurrentUser);
            InitializeComponent();
            if (Users.Count < 1)
            {
                NoMatchesPopUp();
            }
        };

        stackLayout.Add(stackLayoutTwo);
        stackLayoutTwo.Add(verticalStackLayout);
        verticalStackLayout.Add(image);
        verticalStackLayout.Add(labelName);
        verticalStackLayout.Add(horizontalStackLayout);
        horizontalStackLayout.Add(buttonNo);
        horizontalStackLayout.Add(buttonYes);

        Content = stackLayout;
    }
}