using Model;
using Controller;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public static User User = Auth.User;
    public static List<User> PotentionalMatches { get; set; }
    public static Queue<User> UsersQue = new Queue<User>(PotentionalMatches);
    public List<User> HasUserInLikedList => User.LikedUsers.Where(a => a.Name.Equals(PotentionalMatch.Name)).ToList();
    public List<Drink> Drinks { get; set; }

    public User PotentionalMatch { get; set; }
    public static Model.Match CurrentMatch;

    public Matching()
    {
        Matcher matcher = new Matcher();
        matcher.GeneratePotentialMatches();
        PotentionalMatches = Filter.FilteredPotentionalMatches; 

        InitializeComponent();

        if (UsersQue.Count() == 0)
        {
            NoMatchesPopUp();
        }
        else
        {
            PotentionalMatch = UsersQue.Dequeue();
            Drinks = PotentionalMatch.Favourites;
        }

        BindingContext = this;
    }

    /// <summary>
    /// Loads in the next potentional match
    /// </summary>
    private void NextUser()
    {
        if (UsersQue.Count() > 0)
        {
            PotentionalMatch = UsersQue.Dequeue();
            Drinks = PotentionalMatch.Favourites;

            //Changes the labels on the screen to the current user
            MatchName.Text = PotentionalMatch.Name;
            MatchImage.Source = PotentionalMatch.ProfileImage;
            CitiesName.ItemsSource = PotentionalMatch.Cities;
        }
        else
        {
            NoMatchesPopUp();
        }
    }

    /// <summary>
    /// When clicked on yes checks if both users liked each other if yes than shows popUp if no then loads in next potentional match
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Yes_Clicked(object sender, EventArgs e)
    {
        //Checks if other user liked the auth user
        if (HasUserInLikedList.Count() > 0)
        {
            //Remove Liked of other user who liked auth user
            PotentionalMatch.LikedUsers.Remove(User);

            //Add match on both users
            CurrentMatch = new Model.Match(new List<User> { User, PotentionalMatch });
            User.Matches.Add(CurrentMatch);
            PotentionalMatch.Matches.Add(CurrentMatch);

            //matched pop up
            MatchedPopUp();
        }
        else
        {
            //Add other user to auth user liked list
            User.LikedUsers.Add(PotentionalMatch);

            //Next user
            NextUser();
            InitializeComponent();
        }
    }

    /// <summary>
    /// Pop up with the text no matches found
    /// </summary>
    public void NoMatchesPopUp()
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

        VerticalStackLayout verticalStackLayout = new VerticalStackLayout
        {
            WidthRequest = 300
        };

        Label label = new Label
        {
            Text = "U heeft geen verdere matches meer voor nu. Kijk binnenkort weer eens!",
            FontSize = 26,
            Margin = new Thickness(0, 0, 0, 10)
        };

        stackLayout.Add(stackLayoutTwo);
        stackLayoutTwo.Add(verticalStackLayout);
        verticalStackLayout.Add(label);

        Content = stackLayout;
    }

    /// <summary>
    /// Creates popUp when both users liked each other
    /// </summary>
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

        HorizontalStackLayout horizontalStackLayout = new HorizontalStackLayout { };

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

    /// <summary>
    /// Loads next potentional match when clicked on no button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void No_Clicked(object sender, EventArgs e)
    {
        NextUser();
        InitializeComponent();
    }

    /// <summary>
    /// Loads next potentional match when clicked on back button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Back_Clicked(object sender, EventArgs e)
    {
        NextUser();
        InitializeComponent();
    }

    /// <summary>
    /// Goes to the message screen of the matched users
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Message_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(CurrentMatch));
    }
}