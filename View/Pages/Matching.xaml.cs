using Model;
using Controller;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public static List<User> PotentionalMatches => Filter.FilteredPotentionalMatches;
    public static Queue<User> UsersQue = new Queue<User>(PotentionalMatches);
    public List<Drink> Drinks { get; set; }

    public User PotentionalMatch { get; set; }
    public static Model.Match CurrentMatch;

    public Matching()
    {
        if (UsersQue.Count() == 0)
        {
            NoMatches.IsVisible = true;
        }
        else
        {
            PotentionalMatch = UsersQue.Dequeue();
            Drinks = PotentionalMatch.GetFavourites();
        }

        InitializeComponent();
        BindingContext = this;
    }

    private void NextUser()
    {
        if (UsersQue.Count() > 0)
        {
            PotentionalMatch = UsersQue.Dequeue();
            Drinks = PotentionalMatch.GetFavourites();

            //Changes the labels on the screen to the current user
            MatchName.Text = PotentionalMatch.Name;
            MatchImage.Source = PotentionalMatch.ProfileImage;
            CitiesName.ItemsSource = PotentionalMatch.Cities;
        }
        else
        {
            NoMatches.IsVisible = true;
        }
    }

    private void Yes_Clicked(object sender, EventArgs e)
    {
        //Adds a match to the users.
        CurrentMatch = new Model.Match(new User[] { Auth.getUser(), PotentionalMatch }, new List<Message>());
        Auth.getUser().Matches.Add(CurrentMatch);
        PotentionalMatch.Matches.Add(CurrentMatch);

        //Shows PopUp
        PopUp();
    }

    public void PopUp()
    {
        StackLayout stackLayout = new StackLayout
        {
            BackgroundColor = Colors.Black
        };

        StackLayout stackLayoutTwo = new StackLayout
        {
            HorizontalOptions = LayoutOptions.Center
        };

        VerticalStackLayout verticalStackLayout = new VerticalStackLayout
        {
            WidthRequest = 300
        };

        Label label = new Label
        {
            Text = "It's a match!",
            FontSize = 26,
            Margin = new Thickness(0, 0, 0, 10)
        };

        Image image = new Image
        {
            BackgroundColor = Colors.White,
            Source = PotentionalMatch.ProfileImage,
            HeightRequest = 300,
            WidthRequest = 300
        };

        Label labelName = new Label
        {
            Text = PotentionalMatch.Name,
            TextColor = Colors.White,
            FontSize = 26,
            Margin = new Thickness(0, 10, 0, 20)
        };

        HorizontalStackLayout horizontalStackLayout = new HorizontalStackLayout
        {

        };

        Button buttonBack = new Button
        {
            Text = "Back",
            WidthRequest = 140
        };

        Button buttonMessage = new Button
        {
            Text = "Message",
            WidthRequest = 140,
            Margin = new Thickness(20, 0, 0, 0)
        };

        buttonBack.Clicked += Back_Clicked;
        buttonMessage.Clicked += Message_Clicked;

        stackLayout.Add(stackLayoutTwo);
        stackLayoutTwo.Add(verticalStackLayout);
        verticalStackLayout.Add(label);
        verticalStackLayout.Add(image);
        verticalStackLayout.Add(labelName);
        verticalStackLayout.Add(horizontalStackLayout);
        horizontalStackLayout.Add(buttonBack);
        horizontalStackLayout.Add(buttonMessage);

        Content = stackLayout;
    }

    private void No_Clicked(object sender, EventArgs e)
    {
        NextUser();
        InitializeComponent();
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        NextUser();
        InitializeComponent();
    }

    private void Message_Clicked(object sender, EventArgs e)
    {
      Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(CurrentMatch));
    }
}