using Model;
using Controller;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
//using static Java.Util.Jar.Attributes;

namespace View.Pages;

public partial class Matching : ContentPage
{
    public static List<User> Users { get; set; } = dummydb.Users;
    public static Queue<User> UsersQue = new Queue<User>(Users);
    public User Match { get; set; }

    public List<Drink> Drinks { get; set; }
    public List<Message> messages { get; set; }
    public User[] MatchUsers { get; set; } = new User[2];
    public bool YesBool = false;

    public List<User> PotentionalMatches => Filter.FilteredPotentionalMatches;

    public Matching()
    {
        if (UsersQue.Count() == 0)
        {
            NoMatches.IsVisible = true;
        }

        Match = UsersQue.Dequeue();

        InitializeComponent();
        BindingContext = this;
    }

    private void NextUser()
    {

        if (UsersQue.Count() > 0)
        {
            //Changes the labels on the screen to the current user
            Match = UsersQue.Dequeue();
            MatchName.Text = Match.Name;
            MatchImage.Source = Match.ProfileImage;
            CitiesName.ItemsSource = Match.Cities;
            flexLayout.BindingContext = Match.GetFavourites();

            //Changes the labels on the MsgAndBackPopUp
            MatchFoundImage.Source = Match.ProfileImage;
            MatchFoundName.Text = Match.Name;
        }
        else
        {
            NoMatches.IsVisible = true;
        }
    }

    private void Yes_Clicked(object sender, EventArgs e)
    {
        //Adds a match to the users.
        Model.Match NewMatch = new Model.Match(new User[] { Auth.getUser(), Match }, new List<Message>());
        Auth.getUser().Matches.Add(NewMatch);
        Match.Matches.Add(NewMatch);

        MsgAndBackPopUp.IsVisible = true;
    }

    private void No_Clicked(object sender, EventArgs e)
    {
        NextUser();
    }

    private void Back_Clicked(object sender, EventArgs e)
    {
        MsgAndBackPopUp.IsVisible = false;
        NextUser();
    }

    private void Message_Clicked(object sender, EventArgs e)
    {
        foreach (Model.Match match in Controller.Auth.getUser().Matches)
        {
            foreach (User user in match.Users)
            {
                if (user == Match)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new ChatScreen(match));
                }
            }
        }
    }

}